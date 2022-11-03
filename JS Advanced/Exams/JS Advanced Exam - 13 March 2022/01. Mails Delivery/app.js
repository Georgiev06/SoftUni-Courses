function solve() {
    //Buttons:
    let addBtn = document.getElementById('add').addEventListener('click', addMail);
    let resetBtn = document.getElementById('reset').addEventListener('click', resetMail);

    //Forms:
    let listOfMails = document.getElementById('list');
    let sendMailsList = document.getElementsByClassName('sent-list')[0];
    let deleteMailsList = document.getElementsByClassName('delete-list')[0];

    //Input fields:
    let recipientName = document.getElementById('recipientName');
    let title = document.getElementById('title');
    let message = document.getElementById('message');

    function addMail(e) {
        e.preventDefault();
        let recipientNameValue = recipientName.value;
        let titleValue = title.value;
        let messageValue = message.value;

        if (recipientNameValue === ''
            || titleValue === ''
            || messageValue === '') {
            return;
        }

        createMail(e, recipientNameValue, titleValue, messageValue)
        clearInputFields();
    }

    function createMail(e, recipientName, title, message) {
        let li = document.createElement('li');
        let h4 = document.createElement('h4');
        h4.textContent = `Title: ${title}`;
        let secondH4 = document.createElement('h4');
        secondH4.textContent = `Recipient Name: ${recipientName}`;
        let span = document.createElement('span');
        span.textContent = `${message}`;
        let div = document.createElement('div');
        div.id = 'list-action';
        let sendBtn = document.createElement('button');
        sendBtn.id = 'send'
        sendBtn.textContent = 'Send';
        sendBtn.addEventListener('click', (e) => {
            sendMail(e, recipientName, title, message)
        });

        let deleteBtn = document.createElement('button');
        deleteBtn.id = 'delete';
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', (e) => {
            deleteMail(e, recipientName, title, message)
        });

        li.appendChild(h4);
        li.appendChild(secondH4);
        li.appendChild(span);

        div.appendChild(sendBtn);
        div.appendChild(deleteBtn);

        li.appendChild(div);

        listOfMails.appendChild(li);
    }

    function sendMail(e, recipientName, title) {
        e.target.parentNode.parentNode.remove();

        let li = document.createElement('li');
        let span = document.createElement('span');
        span.textContent = `To: ${recipientName}`
        let secondSpan = document.createElement('span');
        secondSpan.textContent = `Title: ${title}`
        let div = document.createElement('div');
        div.classList.add('btn');
        let deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', (e) => {
            deleteMail(e, recipientName, title, message)
        });


        div.appendChild(deleteBtn);

        li.appendChild(span);
        li.appendChild(secondSpan);
        li.appendChild(div);

        sendMailsList.appendChild(li);
    }

    function deleteMail(e, recipientName, title) {
        e.target.parentNode.parentNode.remove();

        let li = document.createElement('li');
        let span = document.createElement('span');
        span.textContent = `To: ${recipientName}`
        let secondSpan = document.createElement('span');
        secondSpan.textContent = `Title: ${title}`

        li.appendChild(span);
        li.appendChild(secondSpan);

        deleteMailsList.appendChild(li);
    }

    function clearInputFields() {
        recipientName.value = '';
        title.value = '';
        message.value = '';
    }

    function resetMail(e) {
        recipientName.value = '';
        title.value = '';
        message.value = '';
    }
}
solve()