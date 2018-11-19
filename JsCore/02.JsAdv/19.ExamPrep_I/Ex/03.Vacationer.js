class Vacationer {
    constructor(fullName, creditCard){
        this.fullName = fullName;
        this.idNumber = this.generateIDNumber();

        if(creditCard){
            this.addCreditCardInfo(creditCard);
        } else{
            this.addCreditCardInfo([1111, "", 111]);
        }
        this.wishList = [];
    }

    get fullName(){
        return this._fullName;
    }
    set fullName(tokens){
        let tempFullName = {};
        let namePattern = /^[A-Z][a-z]+$/g;

        if(!tokens){
            throw new Error("Name must include first name, middle name and last name");
        }

        if(tokens.length !== 3){
            throw new Error("Name must include first name, middle name and last name");
        }
        if(!tokens[0].match(namePattern) || !tokens[1].match(namePattern) || !tokens[2].match(namePattern)){
            throw new Error("Invalid full name");
        }

        tempFullName.firstName = tokens[0];
        tempFullName.middleName = tokens[1];
        tempFullName.lastName = tokens[2];

        this._fullName = tempFullName;
    }

    generateIDNumber(){
        let specialChars = ["a", "e", "o", "i", "u"];
        let lastNameLastChar = this.fullName.lastName[this.fullName.lastName.length - 1];

        let firstNameFirstCharAscii = +this.fullName.firstName.charCodeAt(0);
        let id = (231 * firstNameFirstCharAscii + 139 * +this.fullName.middleName.length).toString();

        if(specialChars.includes(lastNameLastChar)){
            id += 8;
        } else{
            id += 7;
        }

        return id;
    }
    addCreditCardInfo(tokens){

        let tempCreditCard = {};

        let cardPattern = /^[0-9]+$/g;

        if(!tokens){
            throw new Error("Missing credit card information");
        }

        if(tokens.length !== 3){
            throw new Error("Missing credit card information");
        }

        if (typeof tokens[0] !== "number" || typeof tokens[2] !== "number") {
            throw new Error("Invalid credit card details");
        }

        tempCreditCard.cardNumber = tokens[0];
        tempCreditCard.expirationDate = tokens[1];
        tempCreditCard.securityNumber = tokens[2];

        this.creditCard = tempCreditCard;
    }
    addDestinationToWishList(destination){
        if(this.wishList.includes(destination)){
            throw new Error("Destination already exists in wishlist");
        }
        this.wishList.push(destination);
        this.wishList = this.wishList.sort((a, b) => a.length - b.length);
    }
    getVacationerInfo(){
        if(this.wishList.length < 1){
            return "Name: " + this.fullName.firstName + " " + this.fullName.middleName + " " + this.fullName.lastName + "\n" +
                "ID Number: " + this.idNumber + "\n" +
                "Wishlist:\n" +
                "empty\n" +
                "Credit Card:\n" +
                "Card Number: " + this.creditCard.cardNumber + "\n" +
                "Expiration Date: " + this.creditCard.expirationDate + "\n" +
                "Security Number: " + this.creditCard.securityNumber;
        } else{
            return "Name: " + this.fullName.firstName + " " + this.fullName.middleName + " " + this.fullName.lastName + "\n" +
                "ID Number: " + this.idNumber + "\n" +
                "Wishlist:\n" +
                this.wishList.join(", ") + "\n" +
                "Credit Card:\n" +
                "Card Number: " + this.creditCard.cardNumber + "\n" +
                "Expiration Date: " + this.creditCard.expirationDate + "\n" +
                "Security Number: " + this.creditCard.securityNumber;
        }
    }
}

let vac = new Vacationer(["Tania", "Ivanova", "Zhivkova"], [123456789, "10/01/2018", 777]);
console.log(vac.getVacationerInfo());