
$(document).ready(function () {
    //let table = new $('#tableData').DataTable({
    //    ajax: {
    //        url: "https://localhost:44302/api/University",
    //        dataType: "JSON",
    //        dataSrc: "data",
    //        headers: { "Authorization": sessionStorage.getItem("JWToken") }
    //    },
    //    responsive: true,
    //    autoWidth: false,
    //    columns: [
    //        {
    //            data: "",
    //            render: (data, type, row, meta) => {
    //                return meta.row + 1;
    //            }
    //        },
    //        { data: "name" },
    //        {
    //            data: "",
    //            render: (data, type, row) => {
    //                return `<button class="btn btn-success" onclick="return getById(${row.id})"  data-bs-toggle="modal" data-bs-target="#updateModal">Update</button>
    //                        <button class="btn btn-danger" onclick="Delete('${row.id}')" >Delete</button>`;
    //            }
    //        },
    //    ],
    //    dom: 'Bfrtip',
    //    buttons: [
    //        {
    //            extend: 'excelHtml5',
    //            title: 'University Data',
    //            exportOptions: {
    //                columns: [
    //                    function (id, data, node) {
    //                        return $(node).text() === 'Action' ? false : true
    //                    }]
    //            },
    //            className: 'btn btn-primary'
    //        },
    //        {
    //            extend: 'csvHtml5',
    //            title: 'University Data',
    //            exportOptions: {
    //                columns: [
    //                    function (id, data, node) {
    //                        return $(node).text() === 'Action' ? false : true
    //                    }]
    //            },
    //            className: 'btn btn-primary'
    //        },
    //        {
    //            extend: 'pdfHtml5',
    //            title: 'University Data',
    //            exportOptions: {
    //                columns: [
    //                    function (id, data, node) {
    //                        return $(node).text() === 'Action' ? false : true
    //                    }]
    //            },
    //            customize: function (doc) {
    //                doc.pageMargins = [30, 30, 30, 30];
    //                doc.defaultStyle.fontSize = 12;
    //                doc.defaultStyle.alignment = 'center';
    //                doc.styles.tableHeader.fontSize = 13;
    //                //doc.styles.table.widths = ["*", "*"];

    //            }
    //        }
    //    ]
    //});

    //table.buttons().container().appendTo($('.container-fluid', table.table().container()));

    //table.reload();
    Get();
})

function Get() {
    let table = new $('#tableData').DataTable({
        ajax: {
            url: "https://localhost:44302/api/University",
            type: "GET",
            dataType: "JSON",
            dataSrc: "data",
            headers: { "Authorization": "Bearer " + sessionStorage.getItem("JWToken") },
            cache: true,
        },
        columns: [
            {
                data: "",
                render: (data, type, row, meta) => {
                    return meta.row + 1;
                }
            },
            { data: "name" },
            {
                data: "",
                render: (data, type, row) => {
                    return `<button class="btn btn-success" onclick="return getById(${row.id})"  data-bs-toggle="modal" data-bs-target="#updateModal">Update</button>
                            <button class="btn btn-danger" onclick="Delete('${row.id}')" >Delete</button>`;
                }
            },
        ],
        responsive: true,
        autoWidth: false,
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excelHtml5',
                title: 'University Data',
                exportOptions: {
                    columns: [
                        function (id, data, node) {
                            return $(node).text() === 'Action' ? false : true
                        }]
                },
                className: 'btn btn-primary'
            },
            {
                extend: 'csvHtml5',
                title: 'University Data',
                exportOptions: {
                    columns: [
                        function (id, data, node) {
                            return $(node).text() === 'Action' ? false : true
                        }]
                },
                className: 'btn btn-primary'
            },
            {
                extend: 'pdfHtml5',
                title: 'University Data',
                exportOptions: {
                    columns: [
                        function (id, data, node) {
                            return $(node).text() === 'Action' ? false : true
                        }]
                },
                customize: function (doc) {
                    doc.pageMargins = [30, 30, 30, 30];
                    doc.defaultStyle.fontSize = 12;
                    doc.defaultStyle.alignment = 'center';
                    doc.styles.tableHeader.fontSize = 13;
                    //doc.styles.table.widths = ["*", "*"];

                }
            }
        ]
    });

    //table.buttons().container().appendTo($('.container-fluid', table.table().container()));

    //$.ajax({
    //    url: "https://localhost:44302/api/University",
    //    type: "GET",
    //    dataType: "JSON",
    //    headers: { "Authorization": "Bearer " + localStorage.getItem("JWToken") }
    //}).done((res) => {
    //    let temp = "";
    //    $.each(res.data, (key, val) => {
    //        temp += `<tr>
    //        <th>${key + 1}</th>
    //        <th>${val.name}</th>
    //        <th>
    //            <button class="btn btn-success" onclick="return getById(${val.id})"  data-bs-toggle="modal" data-bs-target="#updateModal">Update</button>
    //            <button class="btn btn-danger" onclick="Delete('${val.id}')" >Delete</button>
    //        </th>
    //    </tr>`;
    //    });
    //    $("#listBody").html(temp);
    //})
}

(function Insert() {
    'use strict'

    var forms = document.querySelectorAll('#insertForm')
    Array.prototype.slice.call(forms).forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')

                if (form.checkValidity() === true) {
                    event.preventDefault();
                    form.classList.remove('was-validated')

                    var obj = new Object();
                    obj.name = $("#universityName").val();

                    $.ajax({
                        url: "https://localhost:44302/api/University",
                        type: "POST",
                        headers: {
                            "Accept": "application/json",
                            "Content-Type": "application/json",
                            "Authorization": "Bearer " + sessionStorage.getItem("JWToken")
                        },
                        dataType: "json",
                        data: JSON.stringify(obj),
                        success: function (res) {
                            Get();
                            console.log(res)
                        }
                    }).done((result) => {
                        Swal.fire(
                            'Good job!',
                            'Your data successfully created!',
                            'success'
                        )
                        $('#insertModal').modal('hide');
                        $('#insertForm')[0].reset();
                    }).fail((error) => {
                        //console.log(error);
                        Swal.fire(
                            'Sorry!',
                            'Insert data failed!',
                            'Failed'
                        )
                    })
                }
            }, false)
    })
})()

function getById(id) {
    $.ajax({
        url: "https://localhost:44302/api/University/" + id,
        type: "GET",
        contentType: "application/json; charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#universityIdU').val(result.data.id);
            $('#universityNameU').val(result.data.name);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

(function Update() {
    'use strict'

    var forms = document.querySelectorAll('#updateForm')
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')

                if (form.checkValidity() === true) {
                    event.preventDefault();
                    form.classList.remove('was-validated')

                    var uObj = {
                        id: $('#universityIdU').val(),
                        name: $('#universityNameU').val()
                    };

                    $.ajax({
                        url: "https://localhost:44302/api/University/",
                        data: JSON.stringify(uObj),
                        type: "PUT",
                        headers: { "Authorization": "Bearer " + sessionStorage.getItem("JWToken") },
                        contentType: "application/json; charset=UTF-8",
                        dataType: "json",
                        success: function (result) {
                            Get();
                        },
                        error: function (errormessage) {
                            alert(errormessage.responseText);
                        }
                    }).done((result) => {
                        $('#updateModal').modal('hide');
                        Swal.fire(
                            'Good job!',
                            'Your data successfully updated!',
                            'success'
                        )

                    }).fail((error) => {
                        //console.log(error);
                        Swal.fire(
                            'Sorry!',
                            'Update data failed!',
                            'Failed'
                        )
                    })
                }
            }, false)
        })
})()

function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44302/api/University/' + id,
                method: 'DELETE',
                headers: { "Authorization": "Bearer " + sessionStorage.getItem("JWToken") },
                success: function () {
                    Get();
                },
            }).done((result) => {
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }).fail((error) => {
                Swal.fire(
                    'Sorry!',
                    'Delete data failed!',
                    'Failed'
                )
            })
        }
    })
}

