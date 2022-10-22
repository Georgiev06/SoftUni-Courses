class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length >= this.capacity) {
            throw new Error('Not enough space in the collection.');
        }
        this.books.push({ bookName, bookAuthor, payed: false });
        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    };

    payBook(bookName) {
        const findBook = this.books.find(b => b.bookName === bookName);

        if (!findBook) {
            throw new Error(`${bookName} is not in the collection.`);
        };

        if (findBook.payed) {
            throw new Error(`${bookName} has already been paid.`)
        } else {
            findBook.payed = true;
            return `${findBook.bookName} has been successfully paid.`
        }
    }

    removeBook(bookName) {
        const findBook = this.books.find(b => b.bookName == bookName);

        if (!findBook) {
            throw new Error("The book, you're looking for, is not found.");
        };

        if (!findBook.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        } else {
            const index = this.books.indexOf(findBook);
            this.books.splice(index, 1);
            return `${bookName} remove from the collection.`
        }
    };


    getStatistics(bookAuthor) {
        if (!bookAuthor) {
            let sortedBook = this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            let result = [];
            result.push(`The book collection has ${this.capacity - this.books.length} empty spots left.`);
            sortedBook.map((b) => {
                let paid = b.payed ? 'Has Paid' : 'Not Paid';
                result.push(`${b.bookName} == ${b.bookAuthor} - ${paid}.`);
            });
            return result.join('\n').trim();
        } else {
            let findBook = this.books.find(b => b.bookAuthor == bookAuthor);

            if (findBook) {
                let result = [];
                let paid = findBook.payed ? 'Has Paid' : 'Not Paid';
                result.push(`${findBook.bookName} == ${findBook.bookAuthor} - ${paid}.`);
                return result.join('\n').trim();
            } else {
                throw new Error(`${bookAuthor} is not in the collection.`)
            }
        }
    }
}