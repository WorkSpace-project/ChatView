$(document).ajaxStart(function () {
   // currentelement = 'main';
    //alert("..........ajax start")
    //alert(currentelement);
    //show_waitMe('#' + currentelement)
   // return false; // just in case it’s inside a form
});

$(document).ajaxComplete(function () {
    //console.log("..........ajax complete")
    //console.log(currentelement);
    //$('#' + currentelement).unblock();
   // $('#' + currentelement).waitMe('hide');
   // currentelement = undefined;
});

function show_waitMe(el) {

    $(el).waitMe({
        effect : 'win8',
        text : 'Please wait...',
        bg : 'rgba(255,255,255,0.7)',
        color : '#000',
        maxSize : '',
        waitTime : -1,
        textPos : 'vertical',
        fontSize : '',
        source : '',
        onClose : function() {}
    });
}

function hide_waitMe(el) {
    $(el).waitMe('hide');
}

