console.log('TODO...');
async function solve(e) {
    const url = 'http://localhost:3030/jsonstore/collections/students'
    const form = document.getElementById('form');
    const table = document.querySelector('tbody');
    
    form.addEventListener('submit', submitForm);
      
    table.innerHTML = '';
    const response = await fetch(url);
    const data = await response.json();

    Object.values(data).forEach(student => {
        let row = document.createElement('tr');

        for (const data in student) {
            if (data === '_id') {
                continue; 
            }

            let cell = document.createElement('td');
            cell.textContent = student[data];
            row.appendChild(cell);
        }

        table.appendChild(row);
    });

    async function submitForm(e) {
        e.preventDefault();

        let data = new FormData(form);
        const studentObject = Object.fromEntries(data.entries());

        if (Object.values(studentObject).includes('')) {
            return;
        }

       await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(studentObject)
        });
    }
}

solve();

