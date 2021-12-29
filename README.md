
<h1>Customer Address Book</h1>

<h3>Background</h3>
<p>Story: <br>
  "As a salesperson, I want a customer information management system so that I can market products based on a region's demand."<br><br>
Acceptance Criteria: <br>
  1. The system can display information in a UI. <br>
  2. The system can connect to information in a database. <br>
  3. The system can add new information. <br>
  4. The system can modify existing information. <br>
  5. The system can delete information. <br>
  6. The system can sort information based on State locations. <br>
</p>

<h3>How it works:</h3>
<p>This customer address book works by using a server to connect to a SQL database. Using queries, it displays query results in an interface.</p><br><br>


Home Display View (shows maximum records allowable by default)<br><br>
![CAB_home](CAB_home.PNG)<br><br>

Searching (conducts search based on State information put in by user)<br><br>
![CAB_prequery](CAB_prequery.PNG)<br><br>

Search Conducted (displays sorted table results)<br><br>
![CAB_query](CAB_query.PNG)<br><br>

Adding Data (if all fields are not null, then a new record is added)<br><br>
![CAB_preAdd](CAB_preAdd.PNG)<br><br>

Data Added<br><br>
![CAB_Added](CAB_Added.PNG)<br><br>

Similar to the "Add" function, a record can be changed by double clicking the displayed row of interest in the UI. This fills the Name, Email, and State fields with that data. After changing the data in the field and clicking the "Modify" button, a message box will confirm the update and the changes will be shown in the display. A record can be completely deleted by following the same instructions for the modifying option, but by clicking "Delete" instead of "Modify". 
