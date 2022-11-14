import { html, render } from '../node_modules/lit-html/lit-html.js';
window.addEventListener('load', solve);

async function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   const table = document.querySelector('tbody');

   async function getRequest() {
      const url = 'http://localhost:3030/jsonstore/advanced/table';

      let response = await fetch(url);
      let data = await response.json();

      return [...Object.values(data)];
   }

   let result = await getRequest();

   const tableRowTemplate = (student) => html`
         <td>${student.firstName} ${student.lastName}</td>
         <td>${student.email}</td>
         <td>${student.course}</td>
   `;

   render(result.map(student => html`<tr>${tableRowTemplate(student)}</tr>`), table);

   async function onClick() {
      //TODO:
      let input = document.getElementById('searchField');
      let searchedText = input.value;
      searchedText = searchedText.toLowerCase();

      const tableStudents = document.querySelector('tbody');
      const students = tableStudents.children;

      for(const student of students) {
         student.classList.remove('select');
         input.value = '';

         const studentChildren = student.children;

         for(let row of studentChildren) {
            let text = row.textContent;
            text = text.toLowerCase();
            if(text.includes(searchedText)) {
               student.classList.add('select');
            }
         }
      }
   }
}