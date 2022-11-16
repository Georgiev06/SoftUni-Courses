class LibraryCollection {
    constructor (capacity) {
        this.capacity = capacity;
        this.books = []; 
    }

    addBook (bookName, bookAuthor) {
        if (this.books.length == this.capacity) {
            throw new Error("Not enough space in the collection.");
        }

        this.books.push({
            bookName,
            bookAuthor,
            payed: false
        })

        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName) {
        let book = this.books.find(b => b.bookName === bookName)

        if (!book) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (book.payed === true) {
            throw new Error(`${bookName} has already been paid.`);
        }    

        book.payed = true;
        return `${bookName} has been successfully paid.`
    }

    removeBook(bookName) {
        let book = this.books.find(b => b.bookName === bookName)

        if (!book) {
            throw new Error(`The book, you're looking for, is not found.`);
        }

        if (book.payed === false) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books.pop(book);
        return `${bookName} remove from the collection.`
    }

    getStatistics(bookAuthor) {
        let result = [];
        
        let book = this.books.find(b => b.bookAuthor === bookAuthor)
        
        if (!bookAuthor) {
            result.push(`The book collection has ${this.capacity - this.books.length} empty spots left.`);
            let sortedBooks = this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            sortedBooks.forEach(book => {
                result.push(`${book.bookName} == ${book.bookAuthor} - ${book.payed === true ? `Has Paid` : `Not Paid`}.`)
            });

            return result.join('\n')
        }

        if (!book) {
            throw new Error(`${bookAuthor} is not in the collection.`);
        }

        let filteredBooks = this.books.filter(book => book.bookAuthor === bookAuthor)
        filteredBooks.forEach(book => {
            result.push(`${book.bookName} == ${book.bookAuthor} - ${book.payed === true ? `Has Paid` : `Not Paid`}.`);
        });

        return result.join('\n');
    }
} 

const library = new LibraryCollection(2)
console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
console.log(library.getStatistics('Miguel de Cervantes'));





