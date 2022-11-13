function attachEvents() {
    //console.log('TODO...');
    const baseUrl = 'http://localhost:3030/jsonstore/phonebook';
    const phoneBook = document.getElementById('phonebook');
    
    document.getElementById('btnLoad').addEventListener('click', getRequest)
    document.getElementById('btnCreate').addEventListener('click', postRequest);

    async function getRequest() {
        phoneBook.innerHTML = ''
        const response = await fetch(baseUrl);
        const data = await response.json();

        for (const key of Object.keys(data)) {
            let li = document.createElement('li');
            li.textContent = `${data[key].person}: ${data[key].phone}`
            li.id = data[key]._id;

            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete'
            deleteBtn.addEventListener('click', deleteRequest)

            li.appendChild(deleteBtn)
            phoneBook.appendChild(li);
        }
    }

    async function postRequest() {
        let personName = document.getElementById('person').value;
        let personPhone = document.getElementById('phone').value;

        const requestData =  {
            person: personName,
            phone: personPhone
        }
          
        const response = await fetch(baseUrl, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestData)
        });

        //const data = await response.json();

        person.value = '';
        phone.value = '';
      
        getRequest()
    }

    async function deleteRequest(e) {
        //{<key>:{person:<person>, phone:<phone>}, <key2>:{person:<person2>, phone:<phone2>,…}
        let id = e.target.parentNode.id;

        // requestData = {

        // }

        await fetch(`${baseUrl}/${id}`, {
            method: 'delete',
            // headers: {
            //     'Content-Type': 'application/json'
            // },
            // body: JSON.stringify(requestData)
        });

        document.getElementById(id).remove();

        //const data = await response.json();
    }
}

attachEvents();