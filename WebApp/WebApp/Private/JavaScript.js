setInterval(function () {
        
    xhr = new XMLHttpRequest();

    xhr.open("GET", "../tablausuarios.aspx", true);

    xhr.onreadystatechange = function (){

    if (xhr.readyState == 4 && xhr.status == 200) {
            $("#tablasAJAX").html(xhr.responseText);
    }
}
    xhr.send('');
}, 2000);
