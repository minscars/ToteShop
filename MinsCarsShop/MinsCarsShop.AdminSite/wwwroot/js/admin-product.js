function deleteTote(id_tote){
    const HOST_URL = "https://localhost:7167";
    var check = confirm('Do you want to delete this product?');
    if(check==1){
        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function(){
            
            if(this.readyState==4 && this.status==200){

                var reponse = this.response;

                if(reponse==true){ 
                    window.location.reload(0);
                    alert("Deleted!");
                }
                else{
                    alert("Can't delete!!");
                }
            }
        }
        xhttp.open("GET", HOST_URL +"/product/delete?Id=" + id_tote, true);
        xhttp.send();
    }
}