using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DariaVarya.Web.App.Data;
using DariaVarya.Web.App.Models;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Mail;
using System.Net;
using NuGet.Packaging.Licenses;
using System.Collections.Immutable;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.ComponentModel.DataAnnotations;

namespace DariaVarya.Web.App.Controllers
{
    public class ChangeControlsController : Controller
    {
        private readonly DariaVaryaWebAppContext _context;

        public ChangeControlsController(DariaVaryaWebAppContext context)
        {
            _context = context;
        }

        // GET: ChangeControls
        public async Task<IActionResult> Index()
        {
            //var userName = HttpContext.Session.GetString("UserName");
            //var userRole = HttpContext.Session.GetString("UserRole");

            //ViewBag.UserName = userName;
            //ViewBag.UserRole = userRole;

            var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;
            var userRole = User.FindFirst(x => x.Type.Equals("UserRole", StringComparison.InvariantCulture))?.Value;

            var user = _context.UserProfiles.Where(x => x.Username == userName).FirstOrDefault();
            ViewBag.IsCreatorRole = userRole == "Creator" ? true : false;

            return View(await _context.ChangeControl.ToListAsync());
        }

        // GET: ChangeControls/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeControl = await _context.ChangeControl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (changeControl == null)
            {
                return NotFound();
            }

            var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;
            var userRole = User.FindFirst(x => x.Type.Equals("UserRole", StringComparison.InvariantCulture))?.Value;

            var user = _context.UserProfiles.Where(x => x.Username == userName).FirstOrDefault();

            var approval = _context.Approval.Where(x => x.DocId == id && x.ApproveDate == null);
            var vm = new ChangeControlViewModel(changeControl);

            vm.IsCreator = changeControl.CreatedBy == userName;

            if (approval.Any())
            {

                vm.IsDocumentApproval = true;

                var currentLevel = approval.Select(x => x.Level).Min();

                if (!approval.Any(x => x.ApproveDate == null && x.ApproverUsername == user.Username && x.Level == currentLevel) && !vm.IsCreator)
                    vm.IsDocumentApproval = false;

                vm.Level = currentLevel;
            }

            vm.Role = userRole;

            return View(vm);
        }

        // GET: ChangeControls/Create
        public IActionResult Create()
        {
            // Populate the PabrikOptions with key-value pairs
        //    var items = new List<ItemModel>
        //{
        //    new ItemModel { Id = 1, Name = "Item 1" },
        //    new ItemModel { Id = 2, Name = "Item 2" },
        //    new ItemModel { Id = 3, Name = "Item 3" }
        //};

            var departmentList = new List<SelectListItem>
                {
                new SelectListItem { Value = "1", Text = "Pabrik 1" },
                new SelectListItem { Value = "2", Text = "Pabrik 2" },
                new SelectListItem { Value = "3", Text = "Pabrik 3" }
                };

            ViewBag.items = departmentList;
            return View();
        }

        // POST: ChangeControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody]  ChangeControl changeControl)
        {
            try
            {
                var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;

                //if (ModelState.IsValid)
                //{
                changeControl.CreatedBy = userName;
                changeControl.CreatedDate = DateTime.Now;
                foreach (var d in changeControl.DepartemenLain) {
                    d.CreatedDate = changeControl.CreatedDate;
                    d.CreatedBy = changeControl.CreatedBy;
                }
                _context.Add(changeControl);
                await _context.SaveChangesAsync();
                return Ok(changeControl);
                //}
                //return View(changeControl);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new
                {
                    error = true,
                    message = ex.Message,
                });
            }
           
        }

        // GET: ChangeControls/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeControl = await _context.ChangeControl.Include(x=>x.DepartemenLain).FirstOrDefaultAsync(y=> y.Id == id);
            if (changeControl == null)
            {
                return NotFound();
            }

            var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;
            var userRole = User.FindFirst(x => x.Type.Equals("UserRole", StringComparison.InvariantCulture))?.Value;

            var user = _context.UserProfiles.Where(x => x.Username == userName).FirstOrDefault();

            var approval = _context.Approval.Where(x => x.DocId == id && x.ApproveDate == null);
            var vm = new ChangeControlViewModel(changeControl);

            vm.IsCreator = changeControl.CreatedBy == userName;

            if (approval.Any())
            {

                vm.IsDocumentApproval = true;

                var currentLevel = approval.Select(x => x.Level).Min();

                vm.Level = currentLevel;
            }

            vm.Role = userRole;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(long? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var changeControl = await _context.ChangeControl.Where(x=>x.Id == id).Include(y=>y.DepartemenLain).FirstOrDefaultAsync();
                if (changeControl == null)
                {
                    return NotFound();
                }

                changeControl.Status = "Submitted";

                var user = _context.UserProfiles.Where(x => x.Username == changeControl.CreatedBy).FirstOrDefault();

                var approval = new Approval
                {
                    DocId = changeControl.Id,
                    DocNo = changeControl.DocumentNo,
                    Level = 1,
                    ApproverName = user.ManagerName,
                    ApproverEmail = user.ManagerEmail,
                    ApproverUsername = user.ManagerUsername,
                    CreatedBy = user.CreatedBy,
                    CreatedDate = DateTime.Now
                };

                var listApproval = new List<Approval>
            {
                approval
            };

                var departmentUsers = _context.UserProfiles.AsNoTracking();

                foreach (var item in changeControl.DepartemenLain)
                {
                    var us = departmentUsers.Where(x => x.DepartmentId == item.DepartmentId && x.Role == "Approver" && x.Username != user.ManagerUsername).FirstOrDefault();

                    approval = new Approval
                    {
                        DocId = changeControl.Id,
                        DocNo = changeControl.DocumentNo,
                        Level = 2,
                        ApproverName = us.Name,
                        ApproverEmail = us.Email,
                        ApproverUsername = us.Username,
                        CreatedBy = user.CreatedBy,
                        CreatedDate = DateTime.Now
                    };
                    listApproval.Add(approval);
                }

                
                var cc = departmentUsers.Where(x => x.DepartmentId == user.DepartmentId && x.Role == "Control Center" && x.Username != user.ManagerUsername).FirstOrDefault();

                if (cc != null) {
                    approval = new Approval
                    {
                        DocId = changeControl.Id,
                        DocNo = changeControl.DocumentNo,
                        Level = 3,
                        ApproverName = cc.Name,
                        ApproverEmail = cc.Email,
                        ApproverUsername = cc.Username,
                        CreatedBy = user.CreatedBy,
                        CreatedDate = DateTime.Now
                    };
                    listApproval.Add(approval);
                }

                var qa = departmentUsers.Where(x => x.DepartmentId == user.DepartmentId && x.Role == "QA Manager" && x.Username != user.ManagerUsername).FirstOrDefault();

                if (qa != null)
                {
                    approval = new Approval
                    {
                        DocId = changeControl.Id,
                        DocNo = changeControl.DocumentNo,
                        Level = 4,
                        ApproverName = qa.Name,
                        ApproverEmail = qa.Email,
                        ApproverUsername = qa.Username,
                        CreatedBy = user.CreatedBy,
                        CreatedDate = DateTime.Now
                    };
                    listApproval.Add(approval);
                }


                _context.ChangeControl.Update(changeControl);
                _context.Approval.AddRange(listApproval);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new
                {
                    error = true,
                    message = ex.Message,
                });
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Approve(long? id,string message)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var changeControl = await _context.ChangeControl.FindAsync(id);
                if (changeControl == null)
                {
                    return NotFound();
                }

                changeControl.Notes = message;

                var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;

                var user = _context.UserProfiles.Where(x => x.Username == userName).FirstOrDefault();

                var departmentUsers = _context.UserProfiles.AsNoTracking();

                var approval = _context.Approval.Where(x=>x.DocId == id && x.ApproverUsername == user.Username).FirstOrDefault();

                if (approval != null) {
                    if(approval.Level == 1)
                        changeControl.Status = "Approved By Manager";
                    if (approval.Level == 2)
                        changeControl.Status = "Approved By "+ user.DepartmentName;

                    approval.ApproveDate = DateTime.Now;

                    var totalapprovedDoc = _context.Approval.AsNoTracking().Where(x => x.DocId == id && x.ApproveDate != null).Count();
                    var totalDoc = _context.Approval.AsNoTracking().Where(x => x.DocId == id).Count();

                    if(totalapprovedDoc == totalDoc - 1)
                        changeControl.Status = "Completed";

                    _context.Approval.Update(approval);
                }

                _context.ChangeControl.Update(changeControl);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new
                {
                    error = true,
                    message = ex.Message,
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Revise(long? id, string message)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var changeControl = await _context.ChangeControl.FindAsync(id);
                if (changeControl == null)
                {
                    return NotFound();
                }

                changeControl.Notes = message;

                var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;

                var user = _context.UserProfiles.Where(x => x.Username == userName).FirstOrDefault();

                var approval = _context.Approval.AsNoTracking().Where(x => x.DocId == id && x.ApproverUsername == user.Username).FirstOrDefault();

                if (approval != null)
                {
                    changeControl.Status = "Revised";
                }

                var remonveApproval = _context.Approval.Where(x => x.DocId == id);
                _context.Approval.RemoveRange(remonveApproval);
                _context.ChangeControl.Update(changeControl);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new
                {
                    error = true,
                    message = ex.Message,
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Reject(long? id, string message)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var changeControl = await _context.ChangeControl.FindAsync(id);
                if (changeControl == null)
                {
                    return NotFound();
                }

                changeControl.Notes = message;

                var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;

                var user = _context.UserProfiles.Where(x => x.Username == userName).FirstOrDefault();

                var approval = _context.Approval.AsNoTracking().Where(x => x.DocId == id && x.ApproverUsername == user.Username).FirstOrDefault();

                if (approval != null)
                {
                   changeControl.Status = "Rejected";
                }

                var remonveApproval = _context.Approval.Where(x => x.DocId == id);
                _context.Approval.RemoveRange(remonveApproval);
                _context.ChangeControl.Update(changeControl);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new
                {
                    error = true,
                    message = ex.Message,
                });
            }

        }

        // POST: ChangeControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ChangeControl changeControl)
        {
            try
            {
                //if (id != changeControl.Id)
                //{
                //    return NotFound();
                //}

                //if (ModelState.IsValid)
                //{
                try
                {
                    var userName = User.FindFirst(x => x.Type.Equals("UserName", StringComparison.InvariantCulture))?.Value;
                    var existingData = _context.ChangeControl.Include(y=> y.DepartemenLain).Where(x => x.Id == changeControl.Id).FirstOrDefault();


                    var updatedDepartment = changeControl.DepartemenLain.Where(x => x.ChangeControlId == existingData.Id && x.Id != null).Select(y => y.Id).ToList();
                    var addedDepartment = changeControl.DepartemenLain.Where(x => x.ChangeControlId == existingData.Id && x.Id == null).ToList();

                    //existingData = changeControl;
                    existingData.DocumentNo = changeControl.DocumentNo;
                    existingData.Date = changeControl.Date;
                    existingData.DepartemenCreator = changeControl.DepartemenCreator;
                    existingData.Pabrik = changeControl.Pabrik;
                    existingData.ProductName = changeControl.ProductName;
                    existingData.Deskripsi = changeControl.Deskripsi;
                    existingData.UpdatedDate = DateTime.Now;
                    existingData.UpdatedBy = userName;

                    foreach (var item in existingData.DepartemenLain.Where(x => !updatedDepartment.Contains(x.Id)).ToList()) {
                        existingData.DepartemenLain.Remove(item);
                    }

                    foreach (var addedItem in addedDepartment) {
                        addedItem.CreatedBy = userName;
                        addedItem.CreatedDate = DateTime.Now;
                        existingData.DepartemenLain.Add(addedItem);
                    }


                    //var existingDepartmern = await _context.Departments.Where(x => x.ChangeControlId == x.ChangeControlId).ToListAsync();

                    //var newChildData = changeControl.DepartemenLain.Where(x => x.Id == null);

                    //if (newChildData.Any()) {
                    //    foreach (var item in newChildData)
                    //    {
                    //        item.ChangeControlId = changeControl.Id;
                    //        item.CreatedBy = userName;
                    //        item.CreatedDate = DateTime.Now;
                    //    }

                    //    _context.Departments.AddRange(changeControl.DepartemenLain.Where(x => x.Id == null));
                    //}

                    //if (existingDepartmern.Any() && !changeControl.DepartemenLain.Any())
                    //{
                    //    _context.Departments.RemoveRange(existingData.DepartemenLain);
                    //}
                    //else
                    //{
                    //    _context.ChangeControl.Update(existingData);
                    //}


                    //_context.ChangeControl.Update(changeControl);

                    //var updatedChildData = changeControl.DepartemenLain.Where(x => !existingChildData.Contains(x.Id));
                    //var existingChildData = existingData.DepartemenLain.Select(x => x.Id);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeControlExists(changeControl.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //}

                return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400; // Bad Request
                return Json(new
                {
                    error = true,
                    message = ex.Message,
                });
            }
        }

        // GET: ChangeControls/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeControl = await _context.ChangeControl.Include(x=>x.DepartemenLain)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (changeControl == null)
            {
                return NotFound();
            }

            return View(changeControl);
        }

        // POST: ChangeControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var changeControl = await _context.ChangeControl.Include(x=>x.DepartemenLain).FirstOrDefaultAsync(m => m.Id == id);
            if (changeControl != null)
            {
                _context.ChangeControl.Remove(changeControl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangeControlExists(long? id)
        {
            return _context.ChangeControl.Any(e => e.Id == id);
        }

        [HttpGet]
        public JsonResult GetItems(long? ccId)
        {
            var items = GetYourItems(ccId);
            return Json(items);
        }

        private List<Department> GetYourItems(long? ccId)
        {
            // Simulate data retrieval
            var departId = User.FindFirst(x => x.Type.Equals("DeparmentId", StringComparison.InvariantCulture))?.Value;

            //var existingDeparment = _context.Departments.Where(x => x.ChangeControlId == ccId).Select(y=>y.DepartmentId);

            return new List<Department>
        {
            new Department { DepartmentId = 1, DepartmentName = "Description 1" },
            new Department { DepartmentId = 2, DepartmentName = "Description 2" },
            new Department { DepartmentId = 3, DepartmentName = "Description 3" }
        }.Where(x => x.DepartmentId != Convert.ToInt64(departId)).ToList();
        }

        public async Task<IActionResult> DownloadPdf(long? id)
        {
            var pdfBytes = await DownloadListToPdfAsync(id);
            return File(pdfBytes, "application/pdf", "ItemList.pdf");
        }
        public async Task<byte[]> DownloadListToPdfAsync(long? id)
        {
            var item = _context.ChangeControl.FirstOrDefault(x=>x.Id == id);

            using (var memoryStream = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                //document.Add(new Paragraph("Item List"));
                //document.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(6); // Assuming you have 3 columns: Id, Name, Price
                table.AddCell("DocumentNo");
                table.AddCell("Date");
                table.AddCell("DepartemenCreator");
                table.AddCell("Pabrik");
                table.AddCell("ProductName");
                table.AddCell("Deskripsi");
                //table.AddCell("Status");
                //table.AddCell("Notes");

                //foreach (var item in items)
                //{
                table.AddCell(item.DocumentNo);
                table.AddCell(item.Date.Value.ToString("yyyy-MM-dd"));
                table.AddCell(item.DepartemenCreator);
                table.AddCell(item.Pabrik);
                table.AddCell(item.ProductName);
                table.AddCell(item.Deskripsi);
                //table.AddCell(item.Status);
                //table.AddCell(item.Notes);
                //}

                document.Add(table);
                document.Close();

                return memoryStream.ToArray();
            }
        }
        public ActionResult Search(string pabrik,
            DateTime? dateFrom,
            DateTime? dateTo)
        {
            // Replace YourModel with your actual model and add your filtering logic

            IQueryable<ChangeControl> results = GetListIndex(pabrik, dateFrom, dateTo);

            return PartialView("_SearchResults", results);
        }

        private IQueryable<ChangeControl> GetListIndex(string pabrik, DateTime? dateFrom, DateTime? dateTo)
        {
            var results = _context.ChangeControl.AsQueryable();

            if (!string.IsNullOrEmpty(pabrik))
            {
                results = results.Where(m => m.Pabrik.Contains(pabrik));
            }

            if (dateFrom.HasValue)
            {
                results = results.Where(m => m.Date.Value.Date >= dateFrom.Value.Date); // Adjust the property as needed
            }

            if (dateTo.HasValue)
            {
                results = results.Where(m => m.Date.Value.Date <= dateTo.Value.Date); // Adjust the property as needed
            }

            var searchResults = results.ToList();
            return results;
        }
    }
}
