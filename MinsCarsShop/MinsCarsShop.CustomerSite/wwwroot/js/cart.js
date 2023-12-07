function addToCart(id_tote) {
    var num = 1;
    const url = `https://localhost:7197/cart/addtocart?Id=${id_tote}&amount=${num}`
    let xhr = new XMLHttpRequest()
    xhr.open('GET', url, true)
    xhr.send();
    xhr.onload = function () {
        launch_toast_yes("Added to cart successfully!");   
    }   
}

function addToCartInDetail(id_tote){
    var amount = document.getElementById("detail_amount");
    var num = amount.value;
    console.log(num);
    //Get url of server to run 'localhost:81/cart/add...'
    const url = `https://localhost:7197/cart/addtocart?id=${id_tote}&amount=${num}`
    let xhr = new XMLHttpRequest()
    xhr.open('GET', url, true)
    xhr.send();
    xhr.onload = function () {
        launch_toast_yes("Added to cart successfully!");   
    }   
}

function updateAmount(id_tote, amount_current){
    const url = `https://localhost:7197/cart/UpdateAmount?id=${id_tote}&amount=${amount_current}`
    let xhr = new XMLHttpRequest()
    xhr.open('GET', url, true)
    xhr.send();
    xhr.onload = function () {
        location.reload();
        launch_toast_yes("Update amount successfully!");   
    } 
}

function deleteProductInCart(id_tote){
    var check = confirm('Do you want to delete this product?');
    const url = `https://localhost:7197/cart/delete?id=${id_tote}`
    if(check==true){
        var xhttp = new XMLHttpRequest();
        xhttp.open('GET', url, true)
        xhttp.send();
        xhttp.onload = function(){
            location.reload();
        }
    }
}
//Show message that adding cakes to cart is successful
function launch_toast_yes(message) {
    var x = document.getElementById("toast-yes")
    document.getElementById("toast-yes-desc").innerText = message;
    x.className = "show";
    setTimeout(function(){ 
        x.className = x.className.replace("show", ""); 
    }, 5000);
}

//Show message that adding cakes to cart is failed
function launch_toast_no(message) {
    var x = document.getElementById("toast-no")
    document.getElementById("toast-no-desc").innerText = message;
    x.className = "show";
    setTimeout(function(){ 
        x.className = x.className.replace("show", ""); 
    }, 5000);
}

function order(){
    alert("Check the booking information is the information of this account!")
    var check = confirm('Do you want to booking this order?');
    const url = `https://localhost:7197/cart/order`
    if(check==true){
        var xhttp = new XMLHttpRequest();
        xhttp.open('GET', url, true)
        xhttp.send();
        xhttp.onload = function(){
            location.reload();  
        }
    }
}