window.addEventListener("load", solve);

function solve() {
  //TODO ...
  document.getElementById("publish-btn").addEventListener('click', postData);
  document.getElementById("clear-btn").addEventListener('click', clearData);
  
  let posts = document.getElementById('published-list');
  let reviewList = document.getElementById("review-list");

  let title = document.getElementById("post-title");
  let category = document.getElementById("post-category");
  let content = document.getElementById("post-content");

  function postData(e) {
    e.preventDefault();
    
    let titleValue = title.value;
    let categoryValue = category.value;
    let contentValue = content.value;

    if (titleValue === ''
      || categoryValue === ''
      || contentValue === '') {
      return;
    }

    createPost(e, titleValue, categoryValue, contentValue);
    clearInputFields();
  }

  function createPost(e, title, category, content) {
    let li = document.createElement('li');
    li.classList.add("rpost");

    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = title;

    let p = document.createElement('p');
    p.textContent = category;

    let p2 = document.createElement('p');
    p2.textContent = content;

    article.appendChild(h4);
    article.appendChild(p);
    article.appendChild(p2);

    let editBtn = document.createElement('button');
    editBtn.classList.add('action-btn', 'edit')
    editBtn.textContent = 'Edit';
    editBtn.addEventListener('click', (e) =>
      editPost(e, title, category, content)
    );

    let approveBtn = document.createElement('button');
    approveBtn.classList.add('action-btn', 'approve');
    approveBtn.textContent = 'Approve';
    approveBtn.addEventListener('click', (e) =>
    approvePost(e, title, category, content)
    );

    li.appendChild(article);
    li.appendChild(editBtn);
    li.appendChild(approveBtn);

    reviewList.appendChild(li);
  }

  function clearInputFields() {
    title.value = "";
    category.value = "";
    content.value = "";
  }

  function editPost (e, titleValue, categoryValue, contentValue) {
    e.target.parentElement.remove();
    title.value = titleValue;
    category.value = categoryValue;
    content.value = contentValue;
  }

  function approvePost (e, title, category, content) {
    e.target.parentElement.remove();
  
    let li = document.createElement('li');
    li.classList.add("rpost");

    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = title;

    let p = document.createElement('p');
    p.textContent = category;

    let p2 = document.createElement('p');
    p2.textContent = content;

    article.appendChild(h4);
    article.appendChild(p);
    article.appendChild(p2);

    li.appendChild(article);
    posts.appendChild(li);
  }

  function clearData() {
    Array.from(posts.children).forEach(li => li.remove());
  }
}
