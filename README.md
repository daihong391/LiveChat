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
    
    ![UserPage](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserPage.png)

* **Username Login Page**
    
    * After clicking this button ![LiveChatButton](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserLiveChatButton.png), there will be a panel for user to
enter the first name and last name, such as the following Panel.

    ![UserNamePanel](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserNamePanel.png)
    
    * Both First Name and Last Name are required, or it will be shown as following
    
    ![UerLoginFail](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/FailLoginPanel.png)
    
    * After entering both First Name and Last Name, and clicking Submit button,
you will be redirected to Live Chat Panel
    
    ![Msg Content](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/UserChatPanel.png)
    
    * In this page, you can talk with the worker. 
        * In this bar, you can send message in the text area
        ![Msg Sender](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/MsgSend.png)
        
        * All messages will be shown here
        
        ![Msg Panel](https://raw.githubusercontent.com/daihong391/LiveChat/master/LiveChat/Images/MsgPanel.png)
        
		* Clicking the "Close" Button, this dialog will be closed, and the message will not be shown in Worker Console.

### Help Desk work site(Worker Site)

### Admin Site

---
## Instructions

---
## Demos

