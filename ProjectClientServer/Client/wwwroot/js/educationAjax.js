$.ajax({
    url: "https://localhost:44302/api/Education"
}).done((res) => {
    //console.log(res);
    let temp = "";
    $.each(res.data, (key, val) => {
        temp += `<tr>
            <th>${key + 1}</th>
            <th>${val.major}</th>
            <th>${val.degree}</th>
            <th>${val.gpa}</th>
            <th>${val.universityId}</th>
            <th><button class="btn btn-success" onclick="detail()" data-bs-toggle="modal" data-bs-target="#exampleModalCenter">Detail</button></th>
        </tr>`;
    });
    $("#listBody").html(temp);
})

$(document).ready(function () {
    $("#btnSave").click(function () {
        $.ajax(
            {
                type: "POST", 
                url: "https://localhost:44302/api/Education/Create",   
                data: {  
                    Major: $("#txtMajor").val(),    
                    Degree: $("#txtDegree").val(),
                    Gpa: $("#txtGpa").val(),
                    UniversityId: $("#txtUniversityId").val()
                }

            });

    });
});  