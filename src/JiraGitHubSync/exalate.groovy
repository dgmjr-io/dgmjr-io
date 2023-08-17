def boardIds = ["2"] //Boards which sprints will get synced
if(entityType == "sprint" && boardIds.find{it == sprint.originBoardId}){
    replica.name = sprint.name
    replica.goal = sprint.goal
    replica.state = sprint.state
    replica.startDate = sprint.startDate
    replica.endDate = sprint.endDate
    replica.originBoardId = sprint.originBoardId
}
if(entityType == "issue"){
    replica.issueLinks = issue.issueLinks
   //Executed when syncing an issue to a remote side
   replica.summary = issue.summary
   replica.description = issue.description
   replica.project = issue.project
   
   replica.type = issue.type
	//....
	//other script rules to sync issues
	//sprint....
   replica.customFields.Sprint = issue.customFields.Sprint
}