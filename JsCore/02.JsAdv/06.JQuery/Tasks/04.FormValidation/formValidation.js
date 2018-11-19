function validate() {
    $('#company').on('change', showHideCompany);

    let usernamePattern = /^[a-zA-Z0-9]{3,20}$/g;
    let passwordPattern = /^\w{5,15}$/g;
    let emailPattern = /^.*\@.*\..*$/g;
    let companyFieldNumPattern = /^[1-9]{1}[0-9]{3}$/g;
    
    $('#submit').on('click', submitFunc);

    function submitFunc(ev){
        ev.preventDefault();

        let formIsValid = true;

        if($('#username').val().match(usernamePattern)){
            $('#username').css('border', 'none');
        } else{
            $('#username').css('border-color', 'red');
            formIsValid = false;
        }
        if($('#email').val().match(emailPattern)){
            $('#email').css('border', 'none');
        } else{
            $('#email').css('border-color', 'red');
            formIsValid = false;
        }
        if($('#password').val().match(passwordPattern)){
            $('#password').css('border', 'none');
        } else{
            $('#password').css('border-color', 'red');
            formIsValid = false;
        }
        if($('#confirm-password').val().match(passwordPattern) && $('#password').val().localeCompare($('#confirm-password').val()) == 0){
            $('#confirm-password').css('border', 'none');
        } else{
            $('#confirm-password').css('border-color', 'red');
            formIsValid = false;
        }
        if($('#company').is(':checked')){
            if($('#companyNumber').val().match(companyFieldNumPattern)){
                $('#companyNumber').css('border', 'none');
            } else{
                $('#companyNumber').css('border-color', 'red');
                formIsValid = false;
            }
        }

        if(formIsValid){
            $('#valid').css('display', 'block');
        } else{
            $('#valid').css('display', 'none');
        }
    }
    function showHideCompany(){
        if($('#company').is(':checked')){
            $('#companyInfo').css('display', 'block');
        } else{
            $('#companyInfo').css('display', 'none');
        }
    }
}
