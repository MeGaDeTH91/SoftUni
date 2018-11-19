class BookCollection {
    constructor(genre, room, capacity){
        this.room = room;
        this.shelfCapacity = capacity;
        this.shelfGenre = genre;
        this.shelf = [];
    }

    get room(){
        return this._room;
    }
    set room(val){
        if(val !== "livingRoom" && val !== "bedRoom" && val !== "closet"){
            throw new Error(`Cannot have book shelf in ${val}`);
        }
        this._room = val;
    }

    addBook(bookName, bookAuthor, genre){
        if(this.shelfCondition === 0){
            this.shelf.shift();
        }
        let book = {bookName, bookAuthor, genre};
        this.shelf.push(book);
        this.shelf.sort((a, b) => a.bookAuthor.localeCompare(b.bookAuthor));

        return this;
    }
    throwAwayBook(bookName){
        this.shelf = this.shelf.filter((x) => x.bookName !== bookName);
    }
    showBooks(genre){
        let booksToShow = this.shelf.filter((x) => x.genre === genre);

        let result = "";
        if(booksToShow.length > 0){
            result += `Results for search "${genre}":\n`;
            for (let i = 0; i < booksToShow.length; i++) {
                const booksToShowElement = booksToShow[i];

                result += `\uD83D\uDCD6 ${booksToShowElement.bookAuthor} - "${booksToShowElement.bookName}"\n`;
            }
        }

        return result.trim();
    }
    toString(){
        if(this.shelf.length === 0){
            return "It's an empty shelf";
        } else{
            let result = `"${this.shelfGenre}" shelf in ${this.room} contains:\n`;
            for (let i = 0; i < this.shelf.length; i++) {
                const roomElement = this.shelf[i];
                result += `\uD83D\uDCD6 "${roomElement.bookName}" - ${roomElement.bookAuthor}\n`;
            }
            return result.trim();
        }
    }

    get shelfCondition(){
        return this.shelfCapacity - this.shelf.length;
    }
}

let livingRoom = new BookCollection('Programming', 'livingRoom', 5);

livingRoom.addBook("John Adams", "David McCullough", "history");
livingRoom.addBook("The Guns of August", "Cuentos para pensar", "history");
livingRoom.addBook("Atlas of Remote Islands", "Judith Schalansky");
livingRoom.addBook("Paddle-to-the-Sea", "Holling Clancy Holling");
console.log(livingRoom.showBooks("history"));