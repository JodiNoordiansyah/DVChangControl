$('#btnCreate').click(function (event) {
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

            let dataList = [
                { DepartmentId: 1, DepartmentName: 'hai' },
                { DepartmentId: 2, DepartmentName: 'halo' },
            ];

            // Loop through each row of the table
            $('#selectedItemsTable tbody  tr').each(function () {
                // Get the values from the first two cells (td)
                var id = $(this).find('td').eq(0).text(); // First cell
                var deparmentName = $(this).find('td').eq(1).text(); // Second cell

                // Add the object to the list
                itemList.push({
                    DepartmentId: id,
                    DepartmentName: deparmentName // Convert quantity to a number
                });
            });

            var changeControl = {
                DocumentNo: $('#DocumentNo').val(),
                Date: $('#Date').val() === '' ? null : $('#Date').val(),
                DepartemenCreator: $('#DepartemenCreator').val(),
                Pabrik: $('#Pabrik').val(),
                ProductName: $('#ProductName').val(),
                Deskripsi: $('#Deskripsi').val(),
                Status:'Draft',
                DepartemenLain: itemList
            }

            $.ajax({
                type: "POST",
                url: "/ChangeControls/Create/", // Controller and Action
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
                    itemsTableBody.append(
                        '<tr>' +
                        '<td>' + item.departmentId + '</td>' +
                        '<td>' + item.departmentName + '</td>' +
                        '<td><button class="btn btn-success add-item" data-id="' + item.departmentId + '" data-name="' + item.departmentName + '">Add</button></td>' +
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

    // Store selected items in an array
    var selectedItems = [];

    // Event delegation for dynamically created buttons
    //$(document).on('click', '.add-item', function () {
    //    var itemId = $(this).data('id');
    //    var itemName = $(this).data('name');

    //    if (!selectedItems.includes(itemName)) {
    //        selectedItems.push(itemName); // Add item name to the array
    //    }

    //    //// Set the value in the textbox as a comma-separated string
    //    //$('#selectedItems').val(selectedItems.join(', ')); // Update

    //    // Create a new row with a textbox for the selected item
    //    var newRow = $('<div class="form-group">' +
    //        '<input type="text" class="form-control mb-2" value="' + itemName + '" readonly />' +
    //        '</div>');

    //    // Append the new row to the container
    //    $('#selectedItemsContainer').append(newRow);

    //    // Optionally, you can close the modal after adding the item
    //    $('#itemsModal').modal('hide');
    //});

    $(document).on('click', '.add-item', function () {
        var itemId = $(this).data('id');
        var itemName = $(this).data('name');
        var itemDescription = $(this).data('description');

        // Create a new row for the selected item
        var newRow = $('<tr>' +
            '<td>' + itemId + '</td>' +
            '<td>' + itemName + '</td>' +
            '<td> <button class="btn btn-danger delete-row">Delete</button></td>' +
            '</tr>');

        // Append the new row to the selected items table
        $('#selectedItemsBody').append(newRow);

        // Optionally, you can close the modal after adding the item
        $('#itemsModal').modal('hide');
    });

    $('#selectedItemsTable tbody').on('click', '.delete-row', function () {
        $(this).closest('tr').remove(); // Removes the closest <tr> (the row of the clicked button)
    });
});