$.ajax({
    url: "https://localhost:44302/api/Account",
    type: "GET",
    headers: { "Authorization": "Bearer " + localStorage.getItem("JWToken") }
}).done((res) => {
    //console.log(res);
    let temp = "";
    $.each(res.data, (key, val) => {
        temp += `<tr>
            <th>${key + 1}</th>
            <th>${val.employeeNik}</th>
            <th>${val.password}</th>
            <th><button class="btn btn-success" onclick="detail()" data-bs-toggle="modal" data-bs-target="#exampleModalCenter">Detail</button></th>
        </tr>`;
    });
    $("#listBody").html(temp);
})

function Insert() {
    var obj = new Object();

    obj.employeeNik = $("#accountNik").val();
    obj.password = $("#accountPassword").val();

    $.ajax({
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            
        },
        url: "https://localhost:44302/api/Account",
        type: "POST",
        dataType: "json",
        data: JSON.stringify(obj), //jika terkena 415 unsupported media type (tambahkan headertype Json & JSON.Stringify();)
        success: function () {
            $('#listBody').load("https://localhost:7022/Account");
        }
    }).done((result) => {
        $('#exampleModalCenter').modal('hide');
        alert("created data");

    }).fail((error) => {
        alert("fail created data");
    })
}