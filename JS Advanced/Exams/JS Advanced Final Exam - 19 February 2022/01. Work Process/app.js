function solve() {
    //TODO
    let firstName = document.getElementById('fname');
    let lastName = document.getElementById('lname');
    let email = document.getElementById('email');
    let birth = document.getElementById('birth');
    let position = document.getElementById('position');
    let salary = document.getElementById('salary');
    let addWorkerBtn = document.getElementById('add-worker');

    let tbody = document.getElementById('tbody');
    let message = document.getElementById('message');
    let sum = document.getElementById('sum');
    let budget = 0;

    addWorkerBtn.addEventListener('click', hireWorker);

    function hireWorker(e) {
        e.preventDefault();

        let firstNameValue = firstName.value;
        let lastNameValue = lastName.value;
        let emailValue = email.value;
        let birthValue = birth.value;
        let positionValue = position.value;
        let salaryValue = salary.value;

        if (firstNameValue !== ''
            || lastNameValue !== ''
            || emailValue !== ''
            || birthValue !== ''
            || positionValue !== ''
            || salaryValue !== '') {
            addWorker(e,firstNameValue, lastNameValue, emailValue, birthValue, positionValue, salaryValue);
            clearInputFields();
        }
    }

    function addWorker(e, firstName, lastName, email, birth, position, salary) {
        let tr = document.createElement('tr');
        let fnameTd = document.createElement('td');
        fnameTd.textContent = firstName;
        let lnameTd = document.createElement('td');
        lnameTd.textContent = lastName;
        let emailTd = document.createElement('td');
        emailTd.textContent = email;
        let birthTd = document.createElement('td');
        birthTd.textContent = birth;
        let positionTd = document.createElement('td');
        positionTd.textContent = position;
        let salaryTd = document.createElement('td');
        salaryTd.textContent = salary;
        let buttonsTd = document.createElement('td');
        let firedBtn = document.createElement('button');
        firedBtn.classList.add('fired')
        firedBtn.textContent = 'Fired';
        firedBtn.addEventListener('click', (e) =>
        fireEmployee(e, salary)
        );
        let editBtn = document.createElement('button');
        editBtn.classList.add('edit')
        editBtn.textContent = 'Edit';
        editBtn.addEventListener('click', (e) =>
        editInfo(e, firstName, lastName, email, birth, position, salary)
        );

        buttonsTd.appendChild(firedBtn);
        buttonsTd.appendChild(editBtn);

        tr.appendChild(fnameTd);
        tr.appendChild(lnameTd);
        tr.appendChild(emailTd);
        tr.appendChild(birthTd);
        tr.appendChild(positionTd);
        tr.appendChild(salaryTd)
        tr.appendChild(buttonsTd)

        tbody.appendChild(tr);

        budget += Number(salary);
        sum.textContent = budget.toFixed(2);
        message.appendChild(sum);
    }

    function fireEmployee(e, salary) {
        e.target.parentElement.parentElement.remove();
        budget -= Number(salary);
        sum.textContent = budget.toFixed(2);
        message.appendChild(sum);
    }

    function editInfo(e, firstNameValue, lastNameValue, emailValue, birthValue, positionValue, salaryValue) {
        e.target.parentElement.parentElement.remove();

        firstName.value = firstNameValue;
        lastName.value = lastNameValue;
        email.value = emailValue
        birth.value = birthValue
        position.value = positionValue
        salary.value = salaryValue

        budget -= Number(salaryValue);
        sum.textContent = budget.toFixed(2);
        message.appendChild(sum);
    }

    function clearInputFields() {
        firstName.value = "";
        lastName.value = "";
        email.value = "";
        birth.value = "";
        position.value = "";
        salary.value = "";
    }
}
solve()