
$('#approveDetail').attr("hidden", true)
$('#submitDetail').attr("hidden", true)
$('#rejectDetail').attr("hidden", true)
$('#reviseDetail').attr("hidden", true)
$('#linkEdit').attr("hidden", true)
$(document).ready(function () {

    if ($("#IsDocumentApproval").val() == 'True') {
        $('#linkEdit').attr("hidden", true)
        if ($("#Role").val() == 'Approver' || $("#Role").val() == 'Control Center' || $("#Role").val() == 'QA Manager') {
            $('#approveDetail').attr("hidden", false)
            $('#rejectDetail').attr("hidden", false)
            $('#reviseDetail').attr("hidden", false)
        }
    } else if ($("#IsCreator").val() == 'True' && $("#Role").val() == 'Creator' && ($("#Status").val() != 'Rejected' && ($("#Status").val() == 'Draft' || $("#Status").val() == 'Revised'))) {
        $('#submitDetail').attr("hidden", false)
        $('#linkEdit').attr("hidden", false)
    }

    if (($("#Level").val() == '3' || $("#Level").val() == '4') && $("#IsCreator").val() == 'False') {
        $('#linkEdit').attr("hidden", false)
    }

    $('#approveDetail').click(function (event) {
        Swal.fire({
            title: 'Note',
            input: 'text',
            //inputLabel: 'Note',
            //inputPlaceholder: 'Enter your name',
            showCancelButton: true,
            confirmButtonText: 'Submit',
            cancelButtonText: 'Cancel',
            preConfirm: (inputValue) => {
                //if (!inputValue) {
                //    Swal.showValidationMessage('Please enter your name');
                //}
                return inputValue;
            }
        }).then((result) => {
            if (result.isConfirmed) {
                //Swal.fire(`Your name is: ${result.value}`);
                var message = result.value
                event.preventDefault(); // Prevent the default form submission

                Swal.fire({
                    title: 'Are you sure want to approve this document ?',
                    //text: "You won't be able to revert this!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes',
                    cancelButtonText: 'No'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var id = $('#Id').val(); // Get the ID value
                        $.ajax({
                            type: "POST",
                            url: "/ChangeControls/Approve/", // Controller and Action
                            data: { id: id, message: message }, // Send ID as data
                            beforeSend: function () {
                                Swal.fire({
                                    title: 'Loading...',
                                    text: 'Please wait while we approve the data.',
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
                                    'Approved',
                                    'Your document has been approved.',
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
                            }
                        });
                    }
                });

            }
        });
    });

    $('#reviseDetail').click(function (event) {
        Swal.fire({
            title: 'Note',
            input: 'text',
            //inputLabel: 'Note',
            //inputPlaceholder: 'Enter your name',
            showCancelButton: true,
            confirmButtonText: 'Submit',
            cancelButtonText: 'Cancel',
            preConfirm: (inputValue) => {
                //if (!inputValue) {
                //    Swal.showValidationMessage('Please enter your name');
                //}
                return inputValue;
            }
        }).then((result) => {
            if (result.isConfirmed) {
                //Swal.fire(`Your name is: ${result.value}`);
                var message = result.value
                event.preventDefault(); // Prevent the default form submission

                Swal.fire({
                    title: 'Are you sure want to revise this document ?',
                    //text: "You won't be able to revert this!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes',
                    cancelButtonText: 'No'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var id = $('#Id').val(); // Get the ID value
                        $.ajax({
                            type: "POST",
                            url: "/ChangeControls/Revise/", // Controller and Action
                            data: { id: id, message: message }, // Send ID as data
                            beforeSend: function () {
                                Swal.fire({
                                    title: 'Loading...',
                                    text: 'Please wait while we revise the data.',
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
                                    'Revise',
                                    'Your document has been revised.',
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
                            }
                        });
                    }
                });

            }
        });
    });

    $('#rejectDetail').click(function (event) {
        Swal.fire({
            title: 'Note',
            input: 'text',
            //inputLabel: 'Note',
            //inputPlaceholder: 'Enter your name',
            showCancelButton: true,
            confirmButtonText: 'Submit',
            cancelButtonText: 'Cancel',
            preConfirm: (inputValue) => {
                //if (!inputValue) {
                //    Swal.showValidationMessage('Please enter your name');
                //}
                return inputValue;
            }
        }).then((result) => {
            if (result.isConfirmed) {
                //Swal.fire(`Your name is: ${result.value}`);
                var message = result.value
                event.preventDefault(); // Prevent the default form submission

                Swal.fire({
                    title: 'Are you sure want to reject this document ?',
                    //text: "You won't be able to revert this!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes',
                    cancelButtonText: 'No'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var id = $('#Id').val(); // Get the ID value
                        $.ajax({
                            type: "POST",
                            url: "/ChangeControls/Reject/", // Controller and Action
                            data: { id: id, message: message }, // Send ID as data
                            beforeSend: function () {
                                Swal.fire({
                                    title: 'Loading...',
                                    text: 'Please wait while we reject the data.',
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
                                    'Reject',
                                    'Your document has been rejected.',
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
                            }
                        });
                    }
                });

            }
        });
    });

    $('#submitDetail').click(function (event) {


        event.preventDefault(); // Prevent the default form submission


        Swal.fire({
            title: 'Are you sure want to submit this document ?',
            //text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.isConfirmed) {

                var id = $('#Id').val(); // Get the ID value

                if ($('#submitDetail').text() == 'Submit') {
                    $.ajax({
                        type: "POST",
                        url: "/ChangeControls/Submit/", // Controller and Action
                        data: { id: id }, // Send ID as data
                        beforeSend: function () {
                            Swal.fire({
                                title: 'Loading...',
                                text: 'Please wait while we submit the data.',
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
                                'Submitted',
                                'Your document has been submitted.',
                                'success'
                            ).then((result) => {
                                window.location.href = "/ChangeControls/Index";
                            });
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            Swal.hideLoading()
                            const response = JSON.parse (jqXHR.responseText)
                            Swal.fire(
                                'Failed',
                                response.message,
                                'error'
                            );
                            //alert("An error occurred. Please try again.");
                        }
                    });
                }              
            }
        });


    
    });

    $('#downloadDetail').click(function () {
        var id = $('#Id').val()
        var url = "/ChangeControls/DownloadPdf/" + '?id=' + id;
        window.location.href = url;
    });

});