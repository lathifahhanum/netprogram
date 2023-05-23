$.ajax({
    url: "https://localhost:44302/api/Profiling"
}).done((res) => {
    //console.log(res);
    let temp = "";
    $.each(res.data, (key, val) => {
        temp += `<tr>
            <th>${key + 1}</th>
            <th>${val.employeeNik}</th>
            <th>${val.educationId}</th>
            <th><button class="btn btn-success" onclick="detail()" data-bs-toggle="modal" data-bs-target="#exampleModalCenter">Detail</button></th>
        </tr>`;
    });
    $("#listBody").html(temp);
})