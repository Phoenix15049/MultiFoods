const apiUrl = 'https://localhost:44375/api/Users';

async function login() {
    const loginEmail = document.getElementById('loginEmail').value;
    const loginPhone = document.getElementById('loginPhone').value;
    const loginPassword = document.getElementById('loginPassword').value;

    const loginData = {
        email: loginEmail,
        phone: loginPhone,
        password: loginPassword
    };

    try {
        const response = await fetch(`${apiUrl}/Login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginData)
        });

        const responseData = await response.json();

        if (response.ok) {
            displayResult(`Login successful. Token: ${responseData.token}`);
        } else {
            displayResult(`Login failed. ${responseData}`);
        }
    } catch (error) {
        displayResult('Error during login. ' + error.message);
    }
}

async function register() {
    const registerFirstName = document.getElementById('registerFirstName').value;
    const registerLastName = document.getElementById('registerLastName').value;
    const registerEmail = document.getElementById('registerEmail').value;
    const registerPhone = document.getElementById('registerPhone').value;
    const registerPassword = document.getElementById('registerPassword').value;
    const registerAddress = document.getElementById('registerAddress').value;

    const registerData = {
        customer_ID: 0,
        first_Name: registerFirstName,
        last_Name: registerLastName,
        email: registerEmail,
        phone: registerPhone,
        password: registerPassword,
        address: registerAddress
    };

    try {
        const response = await fetch(`${apiUrl}/Register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(registerData)
        });

        const responseData = await response.json();

        if (response.ok) {
            displayResult(`Registration successful. User ID: ${responseData.customer_ID}`);
        } else {
            displayResult(`Registration failed. ${responseData}`);
        }
    } catch (error) {
        displayResult('Error during registration. ' + error.message);
    }
}

function displayResult(message) {
    const resultElement = document.getElementById('result');
    resultElement.innerHTML = message;
}
