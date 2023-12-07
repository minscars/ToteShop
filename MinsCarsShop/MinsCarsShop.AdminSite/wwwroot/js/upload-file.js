const input = document.getElementById("upload-file")
const output = document.getElementById("upload-file-out")
let imagesArray = []



input.addEventListener("change", () => {
    const file = input.files
    imagesArray.push(file[0])
    displayImages()
})

function displayImages() {
    let images = ""
    imagesArray.forEach((image, index) => {
        images += `<div class="image">
        <img src="${URL.createObjectURL(image)}" alt="image">
        <span onclick="deleteImage(${index})">&times;</span>
        </div>`
    })
    output.innerHTML = images
}

function deleteImage(index) {
    imagesArray.splice(index, 1)
    displayImages()
  }