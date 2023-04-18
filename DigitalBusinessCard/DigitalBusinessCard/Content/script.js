$(document).ready(function() {

    var arrLang={
        
        'tr':{

            '1':'Qr kod',
            '2':'Paylaş',
            '3':'Dolmuş şöförü',
            '4':'Hoşgeldiniz',
            '5':'Rehbere ekle',
            '6':'Telefon',
        },


        'en':{
            '1':'Qr code',
            '2':'Share',
            '3':'Minibus driver',
            '4':'Welcome',
            '5':'Add contacts',
            '6':'Phone',
        },
        
        
    };


    
$('.dropdown-item').click(function() {
    localStorage.setItem('dil', JSON.stringify($(this).attr('id'))); 
    location.reload();
  });

    var lang =JSON.parse(localStorage.getItem('dil'));

    if(lang=="en"){
        $("#drop_yazı").html("English");
    }
    else{
        $("#drop_yazı").html("Türkçe");

    }

    $('a,h5,p,h1,h2,span,li,button,h3,label').each(function(index,element) {
      $(this).text(arrLang[lang][$(this).attr('key')]);
    
  });

});
   
