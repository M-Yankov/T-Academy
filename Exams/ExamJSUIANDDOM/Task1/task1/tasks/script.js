function solve() {
  return function (selector, isCaseSensitive) {
      isCaseSensitive = isCaseSensitive || false;
      //isCaseSensitive = true;
var root = document.querySelector(selector);
      var frag = document.createDocumentFragment();

      var main  = document.createElement('div');
      main.className = 'items-control';

      var addControls = document.createElement('div');
      var searchControls = document.createElement('div');
      var resultControls = document.createElement('div');

      addControls.className = 'add-controls';
      searchControls.className = 'search-controls';
      resultControls.className = 'result-controls';

      // ADD CONTROL Enter text
      var inputLabel = document.createElement('label');
      inputLabel.innerText = 'Enter Text';
      inputLabel.style.fontWeight = 'bold';
      var addInput = document.createElement('input');
      addInput.setAttribute( 'id', 'addInput');
      // button
      var  buttonAdd = document.createElement('button');
      buttonAdd.className = 'button';
      buttonAdd.innerHTML = 'Add';
      // adding to addContorls
      addControls.appendChild(inputLabel);
      addControls.appendChild(addInput);
      addControls.appendChild(buttonAdd);

      // SEARCH CONTROL
      // Searching
      var searchLabel = document.createElement('label');
      searchLabel.innerText = 'Search:';
      var searchInput = document.createElement('input');
      searchInput.setAttribute( 'id', 'searchInput');
      searchControls.appendChild(searchLabel);
      searchControls.appendChild(searchInput)
      //RESULT CONTROL
      var fragElement = document.createDocumentFragment();
      var items = [];
      var itemsList = document.createElement('div');
      itemsList.className = 'items-list';
      fragElement.appendChild(itemsList);
      resultControls.appendChild(fragElement);


      buttonAdd.addEventListener('click', function(ev){
          var target = document.getElementById('addInput');
          var listItem = document.createElement('div');
          listItem.className = 'list-item'
          if(target.value !== ''){
              var text = document.createElement('span');

              text.innerHTML = target.value;

              var elemButton = document.createElement('button');
              elemButton.innerHTML = 'X';
              listItem.appendChild(elemButton);
              listItem.appendChild(text);

              elemButton.addEventListener('click', function(ev){
                  var target = ev.target;
                  console.log(target.nextSibling);
                  itemsList.removeChild(listItem);
                  });

          }
          itemsList.appendChild(listItem);
          fragElement.appendChild(itemsList);
          resultControls.appendChild(fragElement);
      });




      searchInput.addEventListener('input', function(ev){
          var pattern;
          var titles = itemsList.querySelectorAll('span');
          var i,
              len = titles.length;
          if(isCaseSensitive){
              pattern = this.value;
              for (var i = 0; i < len; i+=1) {
                  isPaternFound = titles[i].innerHTML.indexOf(pattern) >= 0;
                  if(!isPaternFound){
                      titles[i].parentNode.style.display = 'none';
                  }
                  else{
                      titles[i].parentNode.style.display = '';
                  }
              }
          }
          else{
              pattern = this.value.toLowerCase();
              for (var i = 0; i < len; i+=1) {
                  isPaternFound = titles[i].innerHTML.toLowerCase().indexOf(pattern) >= 0;
                  if(!isPaternFound){
                      titles[i].parentNode.style.display = 'none';
                  }
                  else{
                      titles[i].parentNode.style.display = '';
                  }
              }
          }
      });



      main.appendChild(addControls);
      main.appendChild(searchControls);
      main.appendChild(resultControls);
      frag.appendChild(main);
      root.appendChild(frag);
  };
}