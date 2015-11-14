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
    UserID  | nvarchar(20) | Not Null | Primary Key
    UserName  | nvarchar(20) | Not Null |
    Password  | nvarchar(20) | Not Null |
    UserLevel  | nvarchar(20) | Not Null |
    EnterBy  | nvarchar(20) | Not Null |
    EnterDate  | nvarchar(20) | Not Null |
    ModifyBy  | nvarchar(20) | Not Null |
    ModifyDate  | nvarchar(20) | Not Null |

* **Message**

    Column  | Type | Null | Key
    --- | --- | --- | ---
    MsgID  | nvarchar(20) | Not Null | Primary Key

### Store Procedures

---
## Front End
There are three parts are applied to this project: **User site**, **Help Desk work site**, and **Admin site**.
### User Site
* **User Website**

    Click this word [User Website](http://livechathenry.azurewebsites.net/) to enter the website as belowing:
    
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
    
    Click this word [Worker Console](http://livechathenry.azurewebsites.net/Worker) to 
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

---
## Instructions

---
## Demos

