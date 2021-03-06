# LiveChat
---
## Targets
This project targets to create a synchronic online communicating application between **Help Desk** and **Customer**. The front end are related with three different sections: **User site**, **Help Desk Work site**, and **Admin site**. Correspondly, the back end is many constituted of two tables: **User table** and **Message table**.

The tools for developing the web application, are **Visual Studio 2012** and **SQL Server 2014**, and the frame of the project is ASP MVC 4. I also use **jquery** to develop the front end, and adopt some tools to make life easier: **dataTables**, **jquery.ui.dialog**, and **ajax**. And These jquery tools can be obtained by seaching **NuGet Centre**.

---
## Back End
As this is not a big project, I adopt two tables and some store procedures for this application:
### Tables
* **User**

    Column  | Type | Null | Key
    --- | --- | --- | ---
    UserID  | nvarchar(10) | Not Null | Primary Key
    UserName  | nvarchar(30) | Not Null |
    Password  | nvarchar(20) | Not Null |
    UserLevel  | nchar(6) | Not Null |
    Dept  | nvarchar(50) | Null |
    Status  | nchar(1) | Not Null |

* **Message**

    Column  | Type | Null | Key
    --- | --- | --- | ---
    MsgID  | nvarchar(20) | Not Null | Primary Key
    MsgContent  | nvarchar(max) | Null |
    UserID  | nvarchar(10) | Null |
    PostTime  | smalldatetime | Null |
    FName  | nvarchar(30) | Not Null |
    LName  | nvarchar(30) | Not Null |
    Status  | nchar(1) | Not Null |

### Store Procedures

* **sp_LC_FindUser**
    
 Find User by UserID

* **sp_LC_GenID**

 Generate a new Message ID by comparing the messages of the database
 
* **sp_LC_GenUserID**

 Generate a new User ID by comparing the userID of the database
 
* **sp_LC_SearchActiveMsg**

 Search all active messages of the database

* **sp_LC_SearchMsg**

 Search the message according to the msgID

* **sp_LC_UserValid_CallCentre**

 Validate the UserName and Password for Worker Console, and return the user information if user validated

* **sp_LC_UserValidate**

 Validate the UserName and Password for Admin Console

---
## Front End
There are three parts are applied to this project: **User site**, **Help Desk work site**, and **Admin site**.
### User Site
* **User Website**

    Click this word [User Website](http://livechathd.azurewebsites.net/) to enter the website as belowing:
    
    ![UserPage](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage/UserPage.png)

* **Username Login Page**
    
    * After clicking this button ![LiveChatButton](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage/UserLiveChatButton.png), there will be a panel for user to
enter the first name and last name, such as the following Panel.

    ![UserNamePanel](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage/UserNamePanel.png)
    
    * Both First Name and Last Name are required, or it will be shown as following
    
    ![UerLoginFail](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage/FailLoginPanel.png)
    
    * After entering both First Name and Last Name, and clicking Submit button,
you will be redirected to Live Chat Panel
    
    ![Msg Content](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage/UserChatPanel.png)
    
    * In this page, you can talk with the worker. 
        * In this bar, you can send message in the text area
        ![Msg Sender](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage/MsgSend.png)
        
        * All messages will be shown here
        
        ![Msg Panel](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage/MsgPanel.png)
        
        * Clicking the "Close" Button, this dialog will be closed, and the message will not be shown in Worker Console.

### Help Desk work site(Worker Site)

* **Admin Account for Testing**

    I have created an admin account for testing:
    
        * Username: Henry
        * Password: 111111

* **Worker Console Page**
    
    Click this word [Worker Console](http://livechathd.azurewebsites.net/Worker) to 
enter the Worker Console Page

    ![Worker Console Login](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/WorkerPage/WorkerLoginPanel.png)
    
* **Worker Login Page**
    
    * If forgetting to enter the Username or Password, it will bw shown
    
    ![LoginFail](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/WorkerPage/WorkerLoginFailed1.png)

    * Else Username and Password are both not matched
    
    ![LoginFail](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/WorkerPage/WorkerLoginFailed2.png)
    
    * When entering the correct Username and Password, you can enter the worker 
console page

* **Console Page**

    ![Worker Console Page](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/WorkerPage/WorkerConsole.png)

    * Clicking Index Button ![Index Button](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/WorkerPage/WorkerConsoleIndex.png), you can return to the Login Page.
    
    * All active messages will be shown there
    
    ![Message Area](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/WorkerPage/WorkerMsgList.png)
    
    * When clicking each message, the Live Chat panel will pop up
    
    ![Worker Live Chat](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/WorkerPage/WorkerLiveChat.png)
    
    And every three seconds, the message content will be refreshed.

### Admin Site

   [Admin Page](http://livechathd.azurewebsites.net/Admin) will direct you to the Login Page of Admin Site of this project.
   
   ![Admin Login](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/AdminPage/Login.png)

   We can still use this same userID and Password to login:
   
    * UserID: Henry
    * Password: 111111

   and the user can login if the UserLevel is Administer.
    
   This admin site mainly include s two parts:
   
    * AccountList
     
![AccountList](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/AdminPage/Account.png)
    
    * MessageList
    
![MessageList](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/AdminPage/Message.png)
    
   If want to modify account, you can go to this site:
   
![AccountEdit](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/AdminPage/AccountEdit.png)
    
---
## Instructions

 * Clicking [User Website](http://livechathd.azurewebsites.net/) to enter User Site.
 * Clicking [Worker Login](http://livechathd.azurewebsites.net/Worker) to enter the login page of Worker Site, and Entering the
Username: Henry and Password: 111111
 * By clicking "Live Chat" button in the following image,
![LiveChat Button](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/Instruct/Instruct1.png)
 
the Username Signin page will pop up.
![Signin Page](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/Instruct/Instruct2.png)

 * After entering both First Name and Last Name, the new message ID will appears in Worker Console's message list.
![Message List](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/Instruct/Instruct3.png)

 * By clicking any message of the message list in the Worker Console, the LiveChat Panel will appear.
![Worker LiveChat](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/Instruct/Instruct4.png)

 * Then entering message and send in each side (user site or worker console), other side will appear the inputed message
in 3 seconds.
![MessageSynmetric](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/Instruct/Instruct5.png)

 * And no matter user leaving or worker leaving, the dialog will be finished.
![Agent Leaving](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/Instruct/Instruct6.png)
![Worker Leaving](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/Instruct/Instruct7.png)

---
## Demos

 * [User Website](http://livechathd.azurewebsites.net/)
 * [Worker Login](http://livechathd.azurewebsites.net/Worker)
 * [Admin Page](http://livechathd.azurewebsites.net/Admin)

