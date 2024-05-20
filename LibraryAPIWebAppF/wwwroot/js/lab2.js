const uri = 'api/Firms';
let firms = [];

function getFirms() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayFirms(data))
        .catch(error => console.error('Unable to get firms.', error));
}

function addFirm() {
    const addNameTextbox = document.getElementById('add-firm-name');
    const firmName = addNameTextbox.value.trim();

    // Check if the firm name is empty
    if (firmName === '') {
        alert('Firm name cannot be empty');
        return; // Exit the function if the firm name is empty
    }

    const firm = {
        firmName: firmName,
        cardDecks: [] // Empty array for card decks, can be configured as needed
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(firm)
    })
        .then(response => response.json())
        .then(() => {
            getFirms();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add firm.', error));
}

function deleteFirm(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getFirms())
        .catch(error => console.error('Unable to delete firm.', error));
}

function displayEditForm(id) {
    const firm = firms.find(firm => firm.firmId === id);

    document.getElementById('edit-firm-id').value = firm.firmId;
    document.getElementById('edit-firm-name').value = firm.firmName;
    document.getElementById('editFirm').style.display = 'block';
}

function updateFirm() {
    const firmId = document.getElementById('edit-firm-id').value;
    const firm = {
        firmId: parseInt(firmId, 10),
        firmName: document.getElementById('edit-firm-name').value.trim(),
        cardDecks: [] // Empty array for card decks, can be configured as needed
    };

    fetch(`${uri}/${firmId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(firm)
    })
        .then(() => getFirms())
        .catch(error => console.error('Unable to update firm.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editFirm').style.display = 'none';
}

function _displayFirms(data) {
    const tBody = document.getElementById('firms');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(firm => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${firm.firmId})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteFirm(${firm.firmId})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(firm.firmName);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(firm.cardDecks.length);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    firms = data;
}

