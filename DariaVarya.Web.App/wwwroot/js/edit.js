
if ($("#Level").val() == '3' || $("#Level").val() == '4') {
    $("#DocumentNo").attr("disabled", false)
    $("#Date").attr("disabled", true)
    $("#DepartemenCreator").attr("disabled", true)
    $("#Pabrik").attr("disabled", true)
    $("#ProductName").attr("disabled", true)
    $("#Deskripsi").attr("disabled", true)
}


$(document).ready(function () {
    $('#openModal').click(function () {
        $.ajax({
            url: "/ChangeControls/GetItems",
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var itemsTableBody = $('#itemsTableBody');
                itemsTableBody.empty(); // Clear existing rows

                $.each(data, function (index, item) {

                    var existingId = [];
                    $('#selectedItemsTable tbody  tr').each(function () {
                        existingId.push($(this).find('td').eq(0).text().trim() == 'undefined' ? '' : $(this).find('td').eq(0).text().trim()); // First cell
                    });

                    if (existingId.includes(item.departmentId.toString())) {
                        return true;
                    }

                    itemsTableBody.append(
                        '<tr>' +
                        '<td>' + item.departmentId + '</td>' +                        
                        '<td>' + item.departmentName + '</td>' +  
                        //'<td>' + item.id + '</td>' +
                        //'<td>' + item.changeControlId + '</td>' +
                        //'<td>' + item.createdBy + '</td>' +
                        //'<td>' + item.createdDate + '</td>' +
                        //'<td>' + item.updatedBy + '</td>' +
                        //'<td>' + item.updatedDate + '</td>' +
                        '<td><button class="btn btn-success add-item" data-departmentid="' + item.departmentId +
                        '" data-departmentname="' + item.departmentName +
                        //'" data-id="' + item.id +
                        //'" data-changecontrolid="' + item.changeControlId +
                        //'" data-createdby="' + item.createdBy +
                        //'" data-createddate="' + item.createdDate +
                        //'" data-updatedby="' + item.updatedBy + 
                        //'" data-updateddate="' + item.updatedDate +
                        '">Add</button></td>' +
                        '</tr>'
                    );
                });

                $('#itemsModal').modal('show'); // Show the modal
            },
            error: function () {
                alert('Error loading data.');
            }
        });
    });

    // jQuery function to delete row on button click
    $('#selectedItemsTable tbody').on('click', '.delete-row', function () {
        $(this).closest('tr').remove(); // Removes the closest <tr> (the row of the clicked button)
    });

    $(document).on('click', '.add-item', function () {
        var itemId = $(this).data('id');
        var itemdeptId = $(this).data('departmentid');
        var itemdeptName = $(this).data('departmentname');
        var itemChangeControlId = $(this).data('changecontrolid');
        var createdDate = new Date();
        var createdBy;
        var createdDate;
        var updatedBy;
        var updatedDate;

        // Create a new row for the selected item
        var newRow = $('<tr>' +
            '<td>' + itemdeptId + '</td>' +
            '<td>' + itemdeptName + '</td>' +
            '<td hidden>' + itemId + '</td>' +
            '<td hidden>' + itemChangeControlId + '</td>' +
            '<td hidden>' + createdBy + '</td>' +
            '<td hidden>' + createdDate + '</td>' +
            '<td hidden>' + updatedBy + '</td>' +
            '<td hidden>' + updatedDate + '</td>' +
            '<td> <button class="btn btn-danger delete-row">Delete</button></td>' +
            '</tr>');     

        // Append the new row to the selected items table
        $('#selectedItemsBody').append(newRow);

        // Optionally, you can close the modal after adding the item
        $('#itemsModal').modal('hide');
    });

    function formatDate(date) {
        // Get year, month, day, hours, minutes, seconds
        var year = date.getFullYear();
        var month = ('0' + (date.getMonth() + 1)).slice(-2); // Month is zero-based, so we add 1
        var day = ('0' + date.getDate()).slice(-2);
        var hours = ('0' + date.getHours()).slice(-2);
        var minutes = ('0' + date.getMinutes()).slice(-2);
        var seconds = ('0' + date.getSeconds()).slice(-2);

        // Return in the format yyyy-mm-dd HH:mm:ss
        return year + '-' + month + '-' + day + ' ' + hours + ':' + minutes + ':' + seconds;
    }
    $('#btnEdit').click(function (event) {
        event.preventDefault(); // Prevent the default form submission

        Swal.fire({
            title: 'Are you sure want to save this document ?',
            //text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.isConfirmed) {

                var itemList = [];

                // Loop through each row of the table
                $('#selectedItemsTable tbody  tr').each(function () {
                    // Get the values from the first two cells (td)
                    var deparmentid = $(this).find('td').eq(0).text().trim() == 'undefined' ? '' : $(this).find('td').eq(0).text().trim(); // First cell
                    var deparmentName = $(this).find('td').eq(1).text().trim() == 'undefined' ? '' : $(this).find('td').eq(1).text().trim(); // Second cell
                    var id = $(this).find('td').eq(2).text().trim() == 'undefined' ? '' : $(this).find('td').eq(2).text().trim(); // Second cell
                    var changeControlId = $('#Id').val(); // Second cell
                    var createdby = $(this).find('td').eq(4).text().trim() == 'undefined' ? '' : $(this).find('td').eq(4).text().trim(); // Second cell
                    var createddate = new Date($(this).find('td').eq(5).text().trim()) == undefined ? new Date() : new Date($(this).find('td').eq(5).text().trim()); // Second cell
                    var updatedby = $(this).find('td').eq(6).text().trim() == 'undefined' ? '' : $(this).find('td').eq(6).text().trim(); // Second cell
                    var updateddate = new Date($(this).find('td').eq(7).text().trim()) == undefined ? '' : new Date($(this).find('td').eq(7).text().trim()) ; // Second cell

                    // Add the object to the list

                    if (id == '') {
                        itemList.push({
                            Id: null,
                            DepartmentId: deparmentid,
                            DepartmentName: deparmentName, // Convert quantity to a number
                            ChangeControlId: changeControlId,
                            //CreatedBy: createdby,
                            //CreatedDate: createddate
                            //UpdatedBy: updatedby, 
                            //UpdatedDate: updateddate
                        });
                    } else {
                        itemList.push({
                            Id: id,
                            DepartmentId: deparmentid,
                            DepartmentName: deparmentName, // Convert quantity to a number
                            ChangeControlId: changeControlId,
                            CreatedBy: createdby,
                            CreatedDate: createddate
                            //UpdatedBy: updatedby, 
                            //UpdatedDate: updateddate
                        });
                    }
                });

                var changeControl = {
                    Id: $('#Id').val(),
                    DocumentNo: $('#DocumentNo').val(),
                    Date: $('#Date').val(),
                    DepartemenCreator: $('#DepartemenCreator').val(),
                    Pabrik: $('#Pabrik').val(),
                    ProductName: $('#ProductName').val(),
                    Deskripsi: $('#Deskripsi').val(),
                    CreatedBy: $('#CreatedBy').val(),
                    CreatedDate: new Date($('#CreatedDate').val()),
                    UpdatedBy: $('#UpdatedBy').val() == '' ? null : $('#UpdatedBy').val(),
                    UpdatedDate: $('#UpdatedDate').val() == '' ? null : new Date($('#UpdatedDate').val()) ,
                    Status: $('#Status').val(),
                    Notes: $('#Notes').val(),
                    DepartemenLain: itemList
                }

                $.ajax({
                    type: "POST",
                    url: "/ChangeControls/Edit/", // Controller and Action
                    contentType: 'application/json',
                    data: JSON.stringify(changeControl),
                    beforeSend: function () {
                        Swal.fire({
                            title: 'Loading...',
                            text: 'Please wait while we save the data.',
                            allowEscapeKey: false,
                            allowOutsideClick: false,
                            didOpen: () => {
                                Swal.showLoading(); // Show loading spinner
                            }
                        });
                    },
                    success: function (response) {
                        Swal.hideLoading()
                        // Show success modal after successful response
                        Swal.fire(
                            'Saved',
                            'Your document has been saved.',
                            'success'
                        ).then((result) => {
                            window.location.href = "/ChangeControls/Index";
                        });
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        Swal.hideLoading()
                        const response = JSON.parse(jqXHR.responseText)
                        Swal.fire(
                            'Failed',
                            response.message,
                            'error'
                        );
                        //alert("An error occurred. Please try again.");
                    }
                });
            }
        });
    });
});