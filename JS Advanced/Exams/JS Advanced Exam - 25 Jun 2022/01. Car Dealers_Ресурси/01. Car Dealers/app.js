window.addEventListener("load", solve);

function solve() {
  //TODO ....

  //1. Get the ['Publish'] button, it should cover the following functionality:
  /*
  When you click the [“Publish”] button, the information from the input fields must be added to the tbody with the id “table-body”. Then, clear all input fields. 
  */
  //document.getElementById('publish').addEventListener('click', publishData);

  //Get the table:
  let table = document.getElementById("table-body");

  //Get the the information from the input fields:
  let makeInput = document.getElementById("make");
  let modelInput = document.getElementById("model");
  let yearInput = document.getElementById("year");
  let fuelInput = document.getElementById("fuel");
  let firstPriceInput = document.getElementById("original-cost");
  let sellingPriceInput = document.getElementById("selling-price");

  let profitMade = 0;
  let totalProfit = document.getElementById("profit");

  document.getElementById('publish').addEventListener('click', publishData);

  function publishData(ev) {
    //This is very important
    /*-->*/ ev.preventDefault();

    //Get the the values from the input fields:
    let makeValue = makeInput.value;
    let modelValue = modelInput.value;
    let yearValue = yearInput.value;
    let fuelValue = fuelInput.value;
    let firstPriceValue = firstPriceInput.value;
    let sellingPriceValue = sellingPriceInput.value;

    //Check: make, model, year, fuel, original-cost and selling price should be non-empty strings. If any of them is empty, the program should not do anything.
    if (makeValue !== ''
      || modelValue !== ''
      || yearValue !== ''
      || fuelValue !== ''
      || sellingPrice > firstPriceValue) {
      addPost(ev, makeValue, modelValue, yearValue, fuelValue, firstPriceValue, sellingPriceValue);
      clearInputFields();
    }
  }

  //Create The HTML structure:
  function addPost(ev, makeInput, modelInput, yearInput, fuelInput, firstPriceInput, sellingPriceInput) {
    let tr = document.createElement('tr');

    //Use this if there is more than one arg:
    tr.setAttribute("class", "row");
    //Use this if there is only one arg:
    //li.classList.add("rpost");

    let make = document.createElement('td');
    make.textContent = makeInput;
    let model = document.createElement('td');
    model.textContent = modelInput;
    let year = document.createElement('td');
    year.textContent = yearInput;
    let fuel = document.createElement('td');
    fuel.textContent = fuelInput
    let price = document.createElement('td');
    price.textContent = firstPriceInput
    let newPrice = document.createElement('td');
    newPrice.textContent = sellingPriceInput;

    let buttons = document.createElement('td');

    let editBtn = document.createElement('button');
    editBtn.classList.add('action-btn', 'edit')
    editBtn.textContent = 'Edit';
    //Add addEventListener to the ["Edit"] button:
    editBtn.addEventListener('click', (ev) =>
      editPost(ev, makeInput, modelInput, yearInput, fuelInput, firstPriceInput, sellingPriceInput)
    );

    let sellBtn = document.createElement('button');
    sellBtn.classList.add('action-btn', 'sell');
    sellBtn.textContent = 'Sell';
    //Add addEventListener to the ["Sell"] button:
    sellBtn.addEventListener('click', (ev) =>
      sellCar(ev, makeInput, modelInput, yearInput, firstPriceInput, sellingPriceInput)
    );

    buttons.appendChild(editBtn);
    buttons.appendChild(sellBtn);

    tr.appendChild(make);
    tr.appendChild(model);
    tr.appendChild(year);
    tr.appendChild(fuel);
    tr.appendChild(price);
    tr.appendChild(newPrice);
    tr.appendChild(buttons);

    table.appendChild(tr);
  }

  function clearInputFields() {
    makeInput.value = "";
    modelInput.value = "";
    yearInput.value = "";
    fuelInput.value = "";
    firstPriceInput.value = "";
    sellingPriceInput.value = "";
  }

  //2. Get the ["Edit"] button, it should cover the following functionality: 
  /*
  When the ["Edit"] button is clicked, the information from the post must be sent to the input fields and the record should be deleted from the tbody with the id "table-body". 
  */
  function editPost(ev, makeValue, modelValue, yearValue, fuelValue, firstPriceValue, sellingPriceValue) {
    //Remove the information from the table
    ev.target.parentElement.parentElement.remove();

    makeInput.value = makeValue;
    modelInput.value = modelValue;
    yearInput.value = yearValue;
    fuelInput.value = fuelValue;
    firstPriceInput.value = firstPriceValue;
    sellingPriceInput.value = sellingPriceValue;
  }

  function sellCar(ev, make, model, year, firstPrice, sellingPrice) {
    ev.target.parentElement.parentElement.remove();

    let cars = document.getElementById('cars-list');

    let profit = sellingPrice - firstPrice;

    //Create The HTML structure:
    let li = document.createElement('li');
    li.className = "each-list";
    let carName = document.createElement('span');
    carName.textContent = make + " " + model;
    let carYear = document.createElement('span');
    carYear.textContent = year;
    let carProfit = document.createElement('span');
    carProfit.textContent = profit;

    li.appendChild(carName);
    li.appendChild(carYear);
    li.appendChild(carProfit);

    cars.appendChild(li);

    profitMade += profit;
    totalProfit.textContent = profitMade.toFixed(2);
  }
}
