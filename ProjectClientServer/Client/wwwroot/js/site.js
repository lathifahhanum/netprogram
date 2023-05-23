// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let button = document.getElementById("button");
let head = document.getElementsByTagName("h1");
let drag = document.getElementById("draggable");
let target = document.getElementById("droptarget");


button.addEventListener('mouseover', function () {
    button.style.backgroundColor = "violet";
});

button.addEventListener('mouseleave', function () {
    button.style.backgroundColor = "white";
});

button.addEventListener('click', function () {
    head[0].innerHTML = "Draggable div active.";
    drag.addEventListener('dragstart', (event) => {
        dragged = event.target;
    });

    target.addEventListener('dragover', (event) => {
        event.preventDefault();
    });


    target.addEventListener("dragenter", (event) => {
        if (event.target.classList.contains("dropzone")) {
            event.target.classList.add("dragover");
        }
    });


    target.addEventListener("dragleave", (event) => {
        if (event.target.classList.contains("dropzone")) {
            event.target.classList.remove("dragover");
        }
    });

    target.addEventListener('drop', (event) => {
        event.preventDefault();
        var data = event.dataTransfer.getData("text");
        if (event.target.className === "dropzone") {
            dragged.parentNode.removeChild(drag);
            event.target.appendChild(dragged);
        }
    });
});

const animals = [
    { name: "fluffy", species: "cat", class: { name: "mamalia" } },
    { name: "Carlo", species: "dog", class: { name: "vertebrata" } },
    { name: "Ursa", species: "cat", class: { name: "mamalia" } },
    { name: "Hamilton", species: "dog", class: { name: "vertebrata" } },
    { name: "Dory", species: "cat", class: { name: "mamalia" } },
]

console.log(animals);

//buat sebuah variable array bernama OnlyCat, dimana hasil looping dari animals
//jika species == cat, maka akan di ambil dan di masukkan ke onlyCat

//jika species == dog, ubah class name tersebut ke 'non-mamalia'

let onlyCat = animals.filter(s => s.species === "cat");
console.log(onlyCat);

animals.filter(a => {
    if (a.species === "dog") {
        a.class.name = "non-mamalia";
    }
})
console.log(animals);