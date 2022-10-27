window.addEventListener("load", solve);

function solve() {
  //TODO ....
  document.getElementById('form-btn').addEventListener('click', addForm);
  document.getElementById('clear-btn').addEventListener('click', clearForm)

  let inProgressForm = document.getElementById('in-progress');
  let finishedForm = document.getElementById('finished');

  let firstName = document.getElementById('first-name');
  let lastName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let gender = document.getElementById('genderSelect');
  let textArea = document.getElementById('task');

  let totalProgressCount = document.getElementById('progress-count')
  let progressCount = 0;

  function addForm(e) {
    e.preventDefault();
    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let ageValue = age.value;
    let genderValue = gender.value;
    let textAreaValue = textArea.value;

    if (firstNameValue === ''
      || lastNameValue === ''
      || ageValue === ''
      || textAreaValue === '') {
        return;
    }

    createForm(e, firstNameValue, lastNameValue, ageValue, genderValue, textAreaValue)
    clearInputFields();
  }

  function createForm(e, firstName, lastName, age, gender, textArea) {
    let li = document.createElement('li');
    li.classList.add("each-line");
    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = `${firstName} ${lastName}`
    let p = document.createElement('p');
    p.textContent = `${gender ? "Male" : "Female"}, ${age}`
    let p2 = document.createElement('p');
    p2.textContent = `Dish description: ${textArea}`;

    let editBtn = document.createElement('button');
    editBtn.classList.add('edit-btn');
    editBtn.textContent = 'Edit';
    editBtn.addEventListener('click', (e) =>
      editForm(e, firstName, lastName, age, gender, textArea)
    );

    let completeBtn = document.createElement('button');
    completeBtn.classList.add('complete-btn');
    completeBtn.textContent = 'Mark as complete';
    completeBtn.addEventListener('click', (e) =>
      completeForm(e, firstName, lastName, age, gender, textArea)
    );

    article.appendChild(h4);
    article.appendChild(p);
    article.appendChild(p2);

    li.appendChild(article);
    li.appendChild(editBtn);
    li.appendChild(completeBtn);

    inProgressForm.appendChild(li);
    progressCount++;

    totalProgressCount.textContent = progressCount;
  }

  function editForm(e, firstNameValue, lastNameValue, ageValue, genderValue, textAreaValue) {
    e.target.parentElement.remove();

    firstName.value = firstNameValue;
    lastName.value = lastNameValue
    age.value = ageValue;
    gender.value = genderValue;
    textArea.value = textAreaValue;

    progressCount--;
    totalProgressCount.textContent = progressCount;
  }

  function completeForm(e, firstName, lastName, age, gender, textArea) {
    e.target.parentElement.remove();

    let li = document.createElement('li');
    li.classList.add("each-line");
    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = `${firstName} ${lastName}`
    let p = document.createElement('p');
    p.textContent = `${gender ? "Male" : "Female"}, ${age}`
    let p2 = document.createElement('p');
    p2.textContent = `Dish description: ${textArea}`;

    article.appendChild(h4);
    article.appendChild(p);
    article.appendChild(p2);

    li.appendChild(article);

    finishedForm.appendChild(li);

    progressCount--;
    totalProgressCount.textContent = progressCount;

  }

  function clearForm() {
    Array.from(finishedForm.children).forEach(li => li.remove());
  }

  function clearInputFields() {
    firstName.value = '';
    lastName.value = '';
    age.value = '';
    gender.value = '';
    textArea.value = '';
  }
}
