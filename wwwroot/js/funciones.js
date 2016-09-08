
var googleUser = {};
var startApp = function() {
    gapi.load('auth2', function() {
        auth2 = gapi.auth2.init({
            client_id: '109246579561-1v82qriqn7i92jjhltb0hgas8b9he4b9.apps.googleusercontent.com',
            cookiepolicy: 'single_host_origin'
        });
        attachSignin(document.getElementById('customBtn'));
    });
};

function attachSignin(element) {
    
    auth2.attachClickHandler(element, {},
        function(googleUser) {
            var profile = googleUser.getBasicProfile();
            console.log('ID: ' + profile.getId());
            console.log('Name: ' + profile.getName());
            console.log('Image URL: ' + profile.getImageUrl());
            console.log('Email: ' + profile.getEmail());
            var id_token = googleUser.getAuthResponse().id_token;
            console.log("ID Token: " + id_token);

        }, function(error) {
          alert(JSON.stringify(error, undefined, 2));
        });
  }


function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId());
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail());

    // The ID token you need to pass to your backend:
    var id_token = googleUser.getAuthResponse().id_token;
    console.log("ID Token: " + id_token);
}
function onSuccess(googleUser) {
    console.log('Logged in as: ' + googleUser.getBasicProfile().getName());
}
function onFailure(error) {
    console.log('Error: ' + error);
}
function renderButton() {
    alert('hola');
    gapi.signin2.render('my-signin2', {
    'scope': 'profile email',
    'width': 240,
    'height': 50,
    'longtitle': true,
    'theme': 'dark',
    'onsuccess': onSuccess,
    'onfailure': onFailure
    });
}

$(document).ready(function($) {
    
    startApp();

    $('.sectionhide').hide();
    $('.btn-mas-tematicas').click(function(){
        $('.sectionhide').slideDown();
    });
    
    //Franja de procesos
    $('.m-proceso').each(function () {
        var alto = $(this).height();
        alto = alto - 120;
        $(this).find('.recta').css('height', alto + 'px');
    });
    
    $('.lightbox').fancybox();
    //$('.como-funciona').parallax();
    
    
    $(function () {
        var $win = $(window);
        
        $win.scroll(function () {
            var posicion = $win.scrollTop();

            if(posicion > 100) {
                $('.navbar-fixed-top').css('opacity','1');
                $('.navbar-fixed-top').css('border-bottom','1px solid #000');
            }       
            else {
                $('.navbar-fixed-top').css('opacity','0.7');
                $('.navbar-fixed-top').css('border-bottom','0');
            }
        });
        
    });
    
    $.fn.extend({
        animateCss: function (animationName) {
            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
            $(this).addClass('animated ' + animationName).one(animationEnd, function() {
                $(this).removeClass('animated ' + animationName);
            });
        }
    });
    
    
    
});