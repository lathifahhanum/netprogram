//let h1 = document.getElementsByTagName("h1");
//console.log(h1);

//ajax = asyncronous js and xml
$.ajax({
    url: "https://hp-api.onrender.com/api/characters/"
    //url: "https://rickandmortyapi.com/api/character/"
    //url: "https://pokeapi.co/api/v2/pokemon/"
}).done((res) => {
    //console.log(res);
    let temp = "";
    $.each(res, (key, val) => {
        temp += `<tr>
            <th>${key + 1}</th>
            <th>${val.name}</th>
            <th>${val.id}</th>
            <th><button class="btn btn-success" onclick="detail('https://hp-api.onrender.com/api/character/${val.id}')" data-bs-toggle="modal" data-bs-target="#exampleModalCenter">Detail</button></th>
        </tr>`;
    });
    $("#listBody").html(temp);
})

function detail(stringUrl) {
    $.ajax({
        url: stringUrl
    }).done(r => {
        console.log(r);
        $('.bioName').html(r[0].name);
        $('#imgContent').attr("src", r[0].image);
        $('.name').html(r[0].name);
        $('.alternate-name').html(r[0].alternate_names);
        $('.species').html(r[0].species);
        $('.gender').html(r[0].gender);
        $('.house').html(r[0].house);
        $('.birth').html(r[0].dateOfBirth);
        $('.eyeColour').html(r[0].eyeColour);
        $('.hairColour').html(r[0].hairColour);
        $('.ancestry').html(r[0].ancestry);
        $('.patronus').html(r[0].patronus);
        $('.core').html(r[0].wand.core);
        $('.length').html(r[0].wand.length);
        $('.wood').html(r[0].wand.wood);

        if ((r[0].wizard) == true) {
            $('.wizard').html(`<span class="badge bg-success rounded-pill wizard">true</span>`);
        } else {
            $('.wizard').html(`<span class="badge bg-danger rounded-pill wizard">false</span>`);
        };

        if ((r[0].alive) == true) {
            $('.alive').html(`<span class="badge bg-success rounded-pill alive">alive</span>`);
        } else {
            $('.alive').html(`<span class="badge bg-danger rounded-pill alive">dead</span>`);
        };
    })
}


//$.ajax({
//    url: "https://pokeapi.co/api/v2/pokemon/",
//    success: (res) => {
//        console.log(res);
//    }
//})

//$.ajax({
//    url: "https://localhost:44302/api/Employee"
//}).done((res) => {
//    //console.log(res);
//    let temp = "";
//    $.each(res.data, (key, val) => {
//        temp += `<tr>
//            <th>${key + 1}</th>
//            <th>${val.nik}</th>
//            <th>${val.firstName}</th>
//            <th>${val.lastName}</th>
//            <th><button class="btn btn-success" onclick="detail('${val.nik}')" data-bs-toggle="modal" data-bs-target="#exampleModalCenter">Detail</button></th>
//        </tr>`;
//    });
//    $("#listBody").html(temp);
//})

