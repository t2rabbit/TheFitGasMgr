﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetLabelClientMgr.NetLabelMgrServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NetLabelMgrServer.NetLabelMgrSoap")]
    public interface NetLabelMgrSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGatewayList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetGatewayList(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetGatewayInfoByCondAndSetOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetGatewayInfoByCondAndSetOrder(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddGateway", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddGateway(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateGateway", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateGateway(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteGatewayById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DeleteGatewayById(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDevListByGwId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetDevListByGwId(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDevListByProjectGroupId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetDevListByProjectGroupId(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDevListByProjectId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetDevListByProjectId(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDevListByRangeId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetDevListByRangeId(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddDev", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddDev(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DelADevById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DelADevById(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateADev", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateADev(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddNode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddNode(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DelANodeById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DelANodeById(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetCmdToDb", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SetCmdToDb(string strParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SetCmdToDbHTML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void SetCmdToDbHTML();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCmdHandledResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetCmdHandledResult(string strParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllProject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetAllProject(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllProjectHtml", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void GetAllProjectHtml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectByOrgId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetProjectByOrgId(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetProjectByGroupId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetProjectByGroupId(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDevStatusByProject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetDevStatusByProject(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetRegionByProject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetRegionByProject(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddCenterSysUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddCenterSysUser(string strParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddOrgUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddOrgUser(string strParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddNewProjectGroup", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddNewProjectGroup(string strParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddNewProject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddNewProject(string strParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddProjectRegion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddProjectRegion(string strParams);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoginOnePoint", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LoginOnePoint(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LoginOnePointHtml", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void LoginOnePointHtml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SuperLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SuperLogin(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SuperLoginHtml", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void SuperLoginHtml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/OrgLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string OrgLogin(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/OrgLoginHtml", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void OrgLoginHtml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Projectlogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Projectlogin(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ProjectloginHtml", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ProjectloginHtml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Logout", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string Logout(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LogoutHtml", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void LogoutHtml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UploadLoginTimeByUuid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadLoginTimeByUuid(string strJsonParam);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UploadLoginTimeByUuidHtml", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void UploadLoginTimeByUuidHtml();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface NetLabelMgrSoapChannel : NetLabelClientMgr.NetLabelMgrServer.NetLabelMgrSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NetLabelMgrSoapClient : System.ServiceModel.ClientBase<NetLabelClientMgr.NetLabelMgrServer.NetLabelMgrSoap>, NetLabelClientMgr.NetLabelMgrServer.NetLabelMgrSoap {
        
        public NetLabelMgrSoapClient() {
        }
        
        public NetLabelMgrSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NetLabelMgrSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NetLabelMgrSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NetLabelMgrSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetGatewayList(string strJsonParam) {
            return base.Channel.GetGatewayList(strJsonParam);
        }
        
        public string GetGatewayInfoByCondAndSetOrder(string strJsonParam) {
            return base.Channel.GetGatewayInfoByCondAndSetOrder(strJsonParam);
        }
        
        public string AddGateway(string strJsonParam) {
            return base.Channel.AddGateway(strJsonParam);
        }
        
        public string UpdateGateway(string strJsonParam) {
            return base.Channel.UpdateGateway(strJsonParam);
        }
        
        public string DeleteGatewayById(string strJsonParam) {
            return base.Channel.DeleteGatewayById(strJsonParam);
        }
        
        public string GetDevListByGwId(string strJsonParam) {
            return base.Channel.GetDevListByGwId(strJsonParam);
        }
        
        public string GetDevListByProjectGroupId(string strJsonParam) {
            return base.Channel.GetDevListByProjectGroupId(strJsonParam);
        }
        
        public string GetDevListByProjectId(string strJsonParam) {
            return base.Channel.GetDevListByProjectId(strJsonParam);
        }
        
        public string GetDevListByRangeId(string strJsonParam) {
            return base.Channel.GetDevListByRangeId(strJsonParam);
        }
        
        public string AddDev(string strJsonParam) {
            return base.Channel.AddDev(strJsonParam);
        }
        
        public string DelADevById(string strJsonParam) {
            return base.Channel.DelADevById(strJsonParam);
        }
        
        public string UpdateADev(string strJsonParam) {
            return base.Channel.UpdateADev(strJsonParam);
        }
        
        public string AddNode(string strJsonParam) {
            return base.Channel.AddNode(strJsonParam);
        }
        
        public string DelANodeById(string strJsonParam) {
            return base.Channel.DelANodeById(strJsonParam);
        }
        
        public string SetCmdToDb(string strParams) {
            return base.Channel.SetCmdToDb(strParams);
        }
        
        public void SetCmdToDbHTML() {
            base.Channel.SetCmdToDbHTML();
        }
        
        public string GetCmdHandledResult(string strParams) {
            return base.Channel.GetCmdHandledResult(strParams);
        }
        
        public string GetAllProject(string strJsonParam) {
            return base.Channel.GetAllProject(strJsonParam);
        }
        
        public void GetAllProjectHtml() {
            base.Channel.GetAllProjectHtml();
        }
        
        public string GetProjectByOrgId(string strJsonParam) {
            return base.Channel.GetProjectByOrgId(strJsonParam);
        }
        
        public string GetProjectByGroupId(string strJsonParam) {
            return base.Channel.GetProjectByGroupId(strJsonParam);
        }
        
        public string GetDevStatusByProject(string strJsonParam) {
            return base.Channel.GetDevStatusByProject(strJsonParam);
        }
        
        public string GetRegionByProject(string strJsonParam) {
            return base.Channel.GetRegionByProject(strJsonParam);
        }
        
        public string AddCenterSysUser(string strParams) {
            return base.Channel.AddCenterSysUser(strParams);
        }
        
        public string AddOrgUser(string strParams) {
            return base.Channel.AddOrgUser(strParams);
        }
        
        public string AddNewProjectGroup(string strParams) {
            return base.Channel.AddNewProjectGroup(strParams);
        }
        
        public string AddNewProject(string strParams) {
            return base.Channel.AddNewProject(strParams);
        }
        
        public string AddProjectRegion(string strParams) {
            return base.Channel.AddProjectRegion(strParams);
        }
        
        public string LoginOnePoint(string strJsonParam) {
            return base.Channel.LoginOnePoint(strJsonParam);
        }
        
        public void LoginOnePointHtml() {
            base.Channel.LoginOnePointHtml();
        }
        
        public string SuperLogin(string strJsonParam) {
            return base.Channel.SuperLogin(strJsonParam);
        }
        
        public void SuperLoginHtml() {
            base.Channel.SuperLoginHtml();
        }
        
        public string OrgLogin(string strJsonParam) {
            return base.Channel.OrgLogin(strJsonParam);
        }
        
        public void OrgLoginHtml() {
            base.Channel.OrgLoginHtml();
        }
        
        public string Projectlogin(string strJsonParam) {
            return base.Channel.Projectlogin(strJsonParam);
        }
        
        public void ProjectloginHtml() {
            base.Channel.ProjectloginHtml();
        }
        
        public string Logout(string strJsonParam) {
            return base.Channel.Logout(strJsonParam);
        }
        
        public void LogoutHtml() {
            base.Channel.LogoutHtml();
        }
        
        public string UploadLoginTimeByUuid(string strJsonParam) {
            return base.Channel.UploadLoginTimeByUuid(strJsonParam);
        }
        
        public void UploadLoginTimeByUuidHtml() {
            base.Channel.UploadLoginTimeByUuidHtml();
        }
    }
}