async function solution() {
    //TODO .....
    let main = document.getElementById('main');
    main.innerHTML = '';

    try {
        let baseUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';
        const response = await fetch(baseUrl);
        const data = await response.json();

        for (const key in data) {
            let article = document.createElement('div');
            article.className = 'accordion';

            article.innerHTML = `<div class="head">
                                <span>${data[key].title}</span>
                                <button class="button" id="${data[key]._id}">More</button>
                                </div>
                                <div class="extra">
                                 <p>${data[key].title}</p>
                                </div>`;

            main.appendChild(article);

            let moreButton = article.querySelector('button');
            moreButton.addEventListener('click', showMore);
        }
    }
    catch (error) {
        if(response.status !== 200) {
            throw new Error('Error didn\'t obtain article list');
        }
    }

    async function showMore(e) {
        let currentArticle = e.currentTarget.parentNode.parentNode;
        let id = e.target.id;
        let extraInfo = currentArticle.querySelector('div.extra');
        try {
            
            let response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);
            let data = await response.json();
            extraInfo.innerHTML = `<p>${data.content}</p>`;
            
            if (e.target.textContent == 'More') {
                e.target.textContent = 'Less';
                extraInfo.style.display = 'block';
            } else {
                e.target.textContent = 'More';
                extraInfo.style.display = 'none';
            }
        } catch (error) {           
            if(response.status !== 200) {
                throw new Error('Error didn\'t obtain article list');
            }
        }
    }
}
solution()