const apiUrl = 'https://localhost:44375/api/items';

async function getAllItems() {
    try {
        const response = await fetch(apiUrl);
        const items = await response.json();
        displayItems(items, 'item-result');
    } catch (error) {
        displayError('Error fetching items: ' + error.message, 'item-result');
    }
}

async function getItemById() {
    const itemId = document.getElementById('itemId').value;
    if (!itemId) {
        displayError('Please enter Item ID', 'item-result');
        return;
    }

    try {
        const response = await fetch(`${apiUrl}/${itemId}`);
        const item = await response.json();
        displayItem(item, 'item-result');
    } catch (error) {
        displayError('Error fetching item by ID: ' + error.message, 'item-result');
    }
}

async function createItem() {
    const itemName = document.getElementById('itemName').value;
    const itemPrice = document.getElementById('itemPrice').value;
    const itemCategory = document.getElementById('itemCategory').value; // Assuming you have an input for Category_ID

    if (!itemName || !itemPrice || !itemCategory) {
        displayError('Please enter Item Name, Price, and Category', 'create-result');
        return;
    }

    const newItem = {
        item_ID: 0,
        item_Name: itemName,
        price: parseFloat(itemPrice),
        category_ID: parseInt(itemCategory)
    };

    try {
        const response = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newItem)
        });

        const responseBody = await response.json();

        if (response.ok) {
            displaySuccess(`Item created with Name: ${itemName}`, 'create-result');
        } else {
            displayError('Error creating item: ' + response.statusText, 'create-result');
        }
    } catch (error) {
        displayError('Error creating item: ' + error.message, 'create-result');
    }
}



async function updateItem() {
    const updateItemId = document.getElementById('updateItemId').value;
    const updateItemName = document.getElementById('updateItemName').value;
    const updateItemPrice = document.getElementById('updateItemPrice').value;
    const updateItemCategory = document.getElementById('updateItemCategory').value; // Assuming you have an input for Category_ID

    if (!updateItemId || !updateItemName || !updateItemPrice || !updateItemCategory) {
        displayError('Please enter Item ID, Name, Price, and Category', 'update-result');
        return;
    }

    const updatedItem = {
        item_ID: parseInt(updateItemId),
        item_Name: updateItemName,
        price: parseFloat(updateItemPrice),
        category_ID: parseInt(updateItemCategory)
    };

    try {
        const response = await fetch(`${apiUrl}/${updateItemId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedItem)
        });

        if (response.ok) {
            displaySuccess('Item updated successfully', 'update-result');
        } else {
            displayError('Error updating item: ' + response.statusText, 'update-result');
        }
    } catch (error) {
        displayError('Error updating item: ' + error.message, 'update-result');
    }
}


async function deleteItem() {
    const deleteItemId = document.getElementById('deleteItemId').value;
    if (!deleteItemId) {
        displayError('Please enter Item ID', 'delete-result');
        return;
    }

    try {
        const response = await fetch(`${apiUrl}/${deleteItemId}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            displaySuccess('Item deleted successfully', 'delete-result');
        } else {
            displayError('Error deleting item: ' + response.statusText, 'delete-result');
        }
    } catch (error) {
        displayError('Error deleting item: ' + error.message, 'delete-result');
    }
}

function displayItems(items, targetElementId) {
    const targetElement = document.getElementById(targetElementId);
    targetElement.innerHTML = '';

    if (items.length === 0) {
        targetElement.innerHTML = 'No items found.';
        return;
    }

    const itemList = document.createElement('ul');
    items.forEach(item => {
        const listItem = document.createElement('li');
        listItem.textContent = `Item ID: ${item.item_ID}, Name: ${item.item_Name}, Price: ${item.price}`;
        itemList.appendChild(listItem);
    });

    targetElement.appendChild(itemList);
}

function displayItem(item, targetElementId) {
    const targetElement = document.getElementById(targetElementId);
    targetElement.innerHTML = '';

    if (!item) {
        targetElement.innerHTML = 'Item not found.';
        return;
    }

    const itemDetails = document.createElement('div');
    itemDetails.innerHTML = `Item ID: ${item.item_ID}, Name: ${item.item_Name}, Price: ${item.price}`;
    targetElement.appendChild(itemDetails);
}
function displaySuccess(message, targetElementId) {
    const targetElement = document.getElementById(targetElementId);
    targetElement.innerHTML = `<div class="success">${message}</div>`;
}

function displayError(message, targetElementId) {
    const targetElement = document.getElementById(targetElementId);
    targetElement.innerHTML = `<div class="error">${message}</div>`;
}
