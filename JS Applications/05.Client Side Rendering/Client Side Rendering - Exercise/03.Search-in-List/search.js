import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js'

const textToSearch = document.getElementById('searchText');
const root = document.getElementById('towns');
const searchBtn = document.querySelector('button');
searchBtn.addEventListener('click', search);
let result = document.getElementById('result');
let matches = 0;

const townTemplate = (town) => html`
   <li>${town}</li>
`;

render(html`<ul>${towns.map(town => townTemplate(town))}</ul>`, root);

function search() {
   const townList = document.querySelector('ul');
   const towns = townList.children;
   for (const town of towns) {
      if (town.textContent.includes(textToSearch.value)) {
         matches++;
         // town.style.fontWeight = 'bold';
         // town.style.textDecoration = 'underline';
         town.classList.add('active');
      }else{
         // town.style.fontWeight = 'normal';
         // town.style.textDecoration = 'none';
      }
   }

   result.textContent = `${matches} matches found`;
}

