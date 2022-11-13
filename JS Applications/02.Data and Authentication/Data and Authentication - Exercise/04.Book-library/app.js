//console.log('My requests...')
function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/collections/books';
    const loadButton = document.getElementById('loadBooks');
    const tableBody = document.querySelector('tbody');
    tableBody.addEventListener('click', updateBook);
    const form = document.querySelector('form');

    form.addEventListener('submit', createBook);
    
    editId = '';
    
    loadButton.addEventListener('click', getBook);
    async function createBook(e) {
        e.preventDefault();

        if ((e.target.children[5]).textContent == 'Save') {
            saveBook(e);
            return;
        }

        let { title, author } = Object.fromEntries(new FormData(form).entries());

        if (title === '' || author === '') {
            return
        }

        const requestData =  {
            title: title,
            author: author
        }
          
        const response = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestData)
        });

        document.querySelector('[name="title"]').value = '';
        document.querySelector('[name="author"]').value = '';

        getBook();
    }

    async function getBook(e) {
        //e.preventDefault();

        let response = await fetch(baseUrl);
        let data = await response.json();

        tableBody.innerHTML = '';

        for (const key of Object.keys(data)) {
            let row = document.createElement('tr');
            let buttonCell = document.createElement('td');

            let editButton = document.createElement('button');
            //editButton.id = data[key]._id;
            editButton.textContent = 'Edit';

            let deleteButton = document.createElement('button');
            //deleteButton.id = data[key]._id;
            deleteButton.textContent = 'Delete';

            buttonCell.appendChild(editButton);
            buttonCell.appendChild(deleteButton);

            let tdTitle = document.createElement('td')
            tdTitle.textContent = data[key].title

            let tdAuthor = document.createElement('td')
            tdAuthor.textContent = data[key].author

            row.appendChild(tdTitle);
            row.appendChild(tdAuthor);
            row.appendChild(buttonCell);

            tableBody.appendChild(row)
        }
    }

    async function updateBook(e) {
        if (e.target.textContent == 'Edit') {
            editId = e.target.id;

            let title = e.target.parentNode.parentNode.children[0].textContent;
            let author = e.target.parentNode.parentNode.children[1].textContent;

            document.querySelector('[name="title"]').value = title;
            document.querySelector('[name="author"]').value = author;

            document.getElementsByTagName('h3')[0].textContent = 'Edit FORM'
            document.querySelector('form button').textContent = 'Save';

            e.target.parentNode.parentNode.remove();
        }
        else {
            deleteBook(e)
        }
    }

    async function saveBook(e) {
        let { title, author } = Object.fromEntries(new FormData(form).entries());

        if (title === '' || author === '') {
            return
        }

        document.querySelector('form h3').textContent = 'FORM';
        document.querySelector('form button').textContent = 'Submit';

        const requestData =  {
            title: title,
            author: author
        }
          
        const response = await fetch(`${baseUrl}/${editId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestData)
        });

        document.querySelector('[name="title"]').value = '';
        document.querySelector('[name="author"]').value = '';

        getBook();
    }

    async function deleteBook(e) {
        await fetch(`${baseUrl}/${e.target.id}`, {
            method: 'delete',
        });

        e.target.parentNode.parentNode.remove();
    }
}

solve()