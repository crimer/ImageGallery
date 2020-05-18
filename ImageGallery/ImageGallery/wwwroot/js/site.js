const uploadForm = document.querySelector('#uploadForm');
const imagePreview = uploadForm.querySelector('#image-preview img');
const inputImage = uploadForm.querySelector("#inputImage");

inputImage.addEventListener("change", function () {
    const file = this.files[0];
    if (file) {
        const reader = new FileReader();
        reader.addEventListener("load", function () {
            imagePreview.setAttribute('src', this.result)
        })
        reader.readAsDataURL(file);
    }
});