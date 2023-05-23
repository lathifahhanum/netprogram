$(document).ready(function () {
    
    Get();
})

function Get() {
    let table = new $('#tabledata').DataTable({
        ajax: {
            url: "https://localhost:44302/api/Employee",
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
            { data: "nik" },
            {
                data: "",
                render: (data, type, row) => {
                    return row.firstName + " " + row.lastName;
                }
            },
            { data: "birthdate" },
            { data: "hiringDate" },
            { data: "email" },
            { data: "phoneNumber" },
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
    //    url: "https://localhost:44302/api/Employee/",
    //    type: "GET",
    //    headers: { "Authorization": "Bearer " + localStorage.getItem("JWToken") },
    //}).done((res) => {
    //    console.log(res);
    //    let temp = "";
    //    $.each(res.data, (key, val) => {
    //        temp += `<tr>
    //        <th>${key + 1}</th>
    //        <th>${val.nik}</th>
    //        <th>${val.firstName + " " + val.lastName}</th>
            
    //        <th>${val.birthdate}</th>
    //        <th>${val.hiringDate}</th>
    //        <th>${val.email}</th>
    //        <th>${val.phoneNumber}</th>
    //        <th>
    //            <button class="btn btn-success" onclick="detail('${val.nik}')" data-bs-toggle="modal" data-bs-target="#detailModal"><i class="bi bi-info-circle-fill"></i></button>
    //            <button class="btn btn-warning" onclick="getById('${val.nik}')" data-bs-toggle="modal" data-bs-target="#updateModal"><i class="bi bi-pencil-square"></i></button>
    //            <button class="btn btn-danger" onclick="Delete('${val.nik}')" data-bs-toggle="modal" data-bs-target="#exampleModalCenter"><i class="bi bi-trash-fill"></i></button>
    //        </th>
    //    </tr>`;
    //    });
    //    $("#listBody").html(temp);
    //})
}

/*<th hidden>${val.gender}</th>*/
function detail(stringUrl) {
    $.ajax({
        url: "https://localhost:44302/api/Employee/" + stringUrl,
        
    }).done(r => {
        console.log(r);
        $('#name').html(r.data.firstName + " " + r.data.lastName);
        $('.nik').html(r.data.nik);
        $('.gender').html(r.data.gender);
        $('.email').html(r.data.email);
        $('.birth').html(r.data.birthdate);
        $('.phone').html(r.data.phoneNumber);

        if ((r.data.gender) == 0) {
            $('.gender').html(`<span>Male</span>`);
        } else {
            $('.gender').html(`<span>Female</span>`);
        };
    })
}

(function Insert() {
    'use strict'

    var forms = document.querySelectorAll('#insertForm')
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

                    var obj = new Object(); 
                    obj.nik = $("#eNik").val();
                    obj.firstName = $("#eFirstName").val();
                    obj.lastName = $("#eLastName").val();
                    obj.gender = detectNumeric($("#eGender").val());
                    obj.birthdate = $("#eBirth").val();
                    obj.hiringDate = $("#eHiring").val();
                    obj.email = $("#eEmail").val();
                    obj.phoneNumber = $("#ePhone").val();

                    $.ajax({
                        headers: {
                            "Accept": "application/json",
                            "Content-Type": "application/json",
                            "Authorization": "Bearer " + sessionStorage.getItem("JWToken"),
                        },
                        url: "https://localhost:44302/api/Employee",
                        type: "POST",
                        dataType: "json",
                        data: JSON.stringify(obj),
                        success: function () {
                            Get();
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
                        console.log(error);
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

function getById(nik) {
    $.ajax({
        url: "https://localhost:44302/api/Employee/" + nik,
        type: "GET",
        contentType: "application/json; charset=UTF-8",
        dataType: "json",
        success: function (r) {
            $("#eNikU").val(r.data.nik);
            $("#eFirstNameU").val(r.data.firstName);
            $("#eLastNameU").val(r.data.lastName);
            $("#eGenderU").val(r.data.gender);
            //$("#eGender").val(r.data.gender);
            $("#eBirthU").val(r.data.birthdate);
            $("#eHiringU").val(r.data.hiringDate);
            $("#eEmailU").val(r.data.email);
            $("#ePhoneU").val(r.data.phoneNumber);
            console.log(r)
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

                    var eObj = {
                        nik: $("#eNikU").val(),
                        firstName: $("#eFirstNameU").val(),
                        lastName: $("#eLastNameU").val(),
                        gender: detectNumeric($("#eGenderU").val()),
                        birthdate: $("#eBirthU").val(),
                        hiringDate: $("#eHiringU").val(),
                        email: $("#eEmailU").val(),
                        phoneNumber: $("#ePhoneU").val()
                    };

                    $.ajax({
                        url: "https://localhost:44302/api/Employee/" + $("#eNikU").val(),
                        data: JSON.stringify(eObj),
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
                url: `https://localhost:44302/api/Employee/${id}`,
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

function detectNumeric(obj) {
    for (var index in obj) {
        if (!isNaN(obj[index])) {
            obj[index] = Number(obj[index]);
        } else if (typeof obj === "object") {
            detectNumeric(obj[index]);
        }
    }
}