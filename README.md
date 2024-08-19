# Employee Reward System for a Telecommunications Company

## Overview

This repository contains a .NET/C# application designed to support a major telecommunications company's customer loyalty reward campaign. The application enables agents to reward loyal customers with discounts on new purchases and provides API integrations for reporting and future scalability across different CRM solutions.

## Key Features

1. **Custom Form Submission:**
   - Agents can submit a custom form to reward up to 5 loyal customers per day for one week.
   - Form validation ensures data accuracy and minimizes potential errors during submission.
  
2. **Error Handling and Logging:**
   - Built-in mechanisms for detecting and handling errors, such as form submission mistakes, to ensure reliable data entry.
   - Logging features to track user activity and errors for auditing and debugging purposes.

3. **CSV Report Integration:**
   - One month after the campaign, a CSV report will be generated containing data on customers who made successful purchases.
   - The application merges this report data with existing customer information to generate insights.

4. **Secure and Scalable API:**
   - Exposes secure APIs to integrate with existing and future CRM solutions.
   - APIs designed with ease of integration and future scalability in mind.

5. **Customer Data Service Integration:**
   - Utilizes the provided `FindPerson` service to retrieve customer data:
     - [FindPerson Service](https://www.crcind.com/csp/samples/SOAP.Demo.cls)

## Architecture

The application is designed to simulate real-world scenarios with a robust architecture that anticipates future needs and simplifies maintenance. The architecture supports modular components that can be easily integrated or extended to accommodate new features or requirements.

## Technologies Used

- **.NET 6**: The latest version of the .NET framework for building secure and scalable applications.
- **C#**: The primary programming language used for the backend logic.
- **API Security**: Implemented using industry-standard authentication and authorization mechanisms.
- **CSV Parsing and Reporting**: Tools for handling and processing CSV data to generate reports.
- **Logging and Error Handling**: Integrated for robust application monitoring and debugging.

## API Documentation

Detailed API documentation will be available in the `/docs` directory, outlining the endpoints, request/response formats, and authentication methods.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more information.

## Contact

For questions or support, please contact me (Belma) at belma.nukic@edu.fit.ba.
