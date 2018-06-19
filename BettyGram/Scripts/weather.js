$(document).ready(function(){
    //initially hide second h1
    $(".two").hide();
    
    function show_second(){
        $(".one").hide();
        $(".two").show();
        setTimeout(show_first, 10000);
    }
    
    
    function show_first(){
        $(".one").show();
        $(".two").hide();
        setTimeout(show_second, 10000);
    }
    
    setTimeout(show_second, 10000);
});
   