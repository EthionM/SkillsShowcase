<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="SkillsShowcase.Tasks.ToDo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .AddButton{
        }
        input.AddButton{
            height:80px;
        }
        .TaskPending{
            width:50%;
            background-color:#b0bec5;
            border: solid 1px gray;
        }
        .TaskDone{
            width:50%;
            background-color:#808e95;
            border: solid 1px gray;
            text-decoration:line-through;
        }
        .DoneButton
        {
        }
        .AddNewTask
        {
            width:50%;
            background-color:#e2f1f8;
            border-color: gray;
            border-width:1px;
            font-size:14px;
            font-weight: bold;
        }
        input[type="submit"].AddNewTaskButton
        {
            width:50%;
            background-color:#e2f1f8;
            border-color: gray;
            border-width:1px;
            font-size:14px;
            font-weight: bold;
        }
        .TaskTitle
        {
            font-size:20px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            padding-left: 10px;
        }
        .TaskDescription
        {
            font-size:18px;
            font-family: Arial, Helvetica, sans-serif;
            padding-left: 5px;
        }
    </style>

        <asp:Repeater runat="server" ID="rptDoneTasks" OnItemDataBound="rptDoneTasks_ItemDataBound" OnItemCommand="rptDoneTasks_ItemCommand">
        <ItemTemplate>
            <asp:HiddenField runat="server" ID="hdnDone" Value='<%# Eval("Done") %>'/>
            <div runat="server" id="divRepeaterTask" style="width:100%;">
                <table>
                    <tr>
                        <td style="height:65%; width:80%;">
                            <asp:Label Text='<%# Eval("Title") %>' runat="server" CssClass="TaskTitle"/>
                            <asp:ImageButton ImageUrl="~/Resources/checked.png" AlternateText="Mark as done" ToolTip="Mark As Done" Height="20px" runat="server" ID="btnMarkDone" CommandName="MarkAsDone" 
                                CssClass="DoneButton" CommandArgument='<%# Eval("IdTask") %>'/>
                        </td>
                        <td style="width:80px;">
                            <div>
                            <label>Added</label>
                            </div>
                            <div>
                            <asp:Label Text='<%# Eval("DateAdded","{0:dd/M/yyyy}") %>' style="text-decoration:none;" runat="server" />
                            </div>
                        </td>
                        <td></td>
                    </tr>
                    <tr id="trDescription" runat="server">
                        <td colspan="3" style="style=height:50px;max-width: 500px;">
                            <asp:Label Text='<%# Eval("Description") %>' CssClass="TaskDescription" runat="server" style="word-wrap: break-word;" />                        
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>

    </asp:Repeater>
    <div id="AddBtnDiv" runat="server" style="display:block;">
        <asp:Button Text="Add New Task" runat="server" ID="btnShowAddNewTask" OnClientClick="showAddTask(); return false;" CssClass="AddNewTaskButton"/>
    </div>
    <div id="AddTaskDiv" runat="server" style="display:none;" class="AddNewTask">
        <table>
            <tr>
                <td style="width:30%; padding-left:5px;">
                    <asp:Label Text="Title" runat="server" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTitle" />
                </td>
                <td rowspan="2" style="vertical-align:middle;">
                    <asp:ImageButton ImageUrl="~/Resources/plus.png" ToolTip="Add" Height="20px" runat="server" ID="btnAdd" OnClientClick="showAddTask();" CssClass="AddButton" style="padding-left:5px;" OnClick="btnAdd_Click"/>
                    <asp:ImageButton ImageUrl="~/Resources/cancel.png" ToolTip="Cancel" Height="20px" runat="server" ID="btnCancelAdd" OnClientClick="showAddTask(); return false;" CssClass="AddButton"/>
                </td>
            </tr>
            <tr>
                <td style="width:30%; padding-left:5px;">
                    <asp:Label Text="Description" runat="server" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function showAddTask() {
            if (document.getElementById('<%=AddTaskDiv.ClientID%>').style.display === 'none') {
                document.getElementById('<%=AddTaskDiv.ClientID%>').style.display = 'block';
                document.getElementById('<%=AddBtnDiv.ClientID%>').style.display = 'none';
            } else {
                document.getElementById('<%=AddTaskDiv.ClientID%>').style.display = 'none';
                document.getElementById('<%=AddBtnDiv.ClientID%>').style.display = 'block';
            }
        }
    </script>

</asp:Content>
