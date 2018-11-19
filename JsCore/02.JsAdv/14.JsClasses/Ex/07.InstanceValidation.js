class CheckingAccount{
    constructor(clientId, email, firstName, lastName){
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }
    get clientId(){
        return this._clientId;
    }
    set clientId(val){
        let numPattern = /^\d{6}$/g;

        if(!val || !val instanceof String || !val.match(numPattern)){
            throw TypeError("Client ID must be a 6-digit number");
        }
        this._clientId = val;
    }
    get email(){
        return this._email;
    }
    set email(val){
        let mailPattern = /^[a-zA-Z0-9_]+\@[a-zA-Z.]+$/g;
        if(!val || !val instanceof String || !val.match(mailPattern)){
            throw TypeError("Invalid e-mail");
        }
        this._email = val;
    }

    get firstName(){
        return this._firstName;
    }
    set firstName(val){
        let namePattern = /^[a-zA-Z]{3,20}$/g;
        if(!val || !val instanceof String || val.length < 3 || val.length > 20){
            throw TypeError("First name must be between 3 and 20 characters long")
        }
        if(!val.match(namePattern)){
            throw TypeError("First name must contain only Latin characters");
        }

        this._firstName = val;
    }

    get lastName(){
        return this._lastName;
    }
    set lastName(val){
        let namePattern = /^[a-zA-Z]{3,20}$/g;
        if(!val || !val instanceof String || val.length < 3 || val.length > 20){
            throw TypeError("Last name must be between 3 and 20 characters long")
        }
        if(!val.match(namePattern)){
            throw TypeError("Last name must contain only Latin characters");
        }

        this._lastName = val;
    }
}