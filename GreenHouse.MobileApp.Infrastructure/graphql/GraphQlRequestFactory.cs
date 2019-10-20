using System;
using GraphQL.Common.Request;

namespace GreenHouse.Mobile.Infrastructure.graphql
{
    public static class GraphQlRequestFactory
    {
        public static GraphQLRequest CreateAccountMutation(string name, string email, string password)
        {
            return new GraphQLRequest
            {
                Query =
                    "mutation addAccount($account: AccountCreateViewModel!) { account { addAccount(account: $account) { id, email, name, type } } }",
                Variables = new {account = new {name, email, password}}
            };
        }

        public static GraphQLRequest CreateFriendMutation(string friendName, string userId)
        {
            return new GraphQLRequest
            {
                Query = "mutation addFriend { friend { addFriend(friendName:\"" + friendName + "\",userId:\"" + userId +
                        "\"){ id, friendId, userId } } }"
            };
        }

        public static GraphQLRequest CreateReportMutation(string userId, string location, string description = "", bool isScheduled = false, DateTime finishedAt = new DateTime())
        {
            return new GraphQLRequest
            {
                Query =
                    "mutation addReport($report: ReportCreateViewModel!) { report { addReport(report : $report){id, userId, description, state, isScheduled, finishedAt, location } } }",
                Variables = new {report = new {userId, description, isScheduled, finishedAt, location}}
            };
        }

        public static GraphQLRequest CreateReportMutationAdd(string userId, string location, string description, bool isScheduled = false)
        {
            return new GraphQLRequest
            {
                Query =
                    "mutation addReport($report: ReportCreateViewModel!) { report { addReport(report : $report){id, userId, description, isScheduled, finishedAt, location } } }",
                Variables = new { report = new { userId, description, isScheduled, location } }
            };
        }

        public static GraphQLRequest CreateAccountQuery()
        {
            return new GraphQLRequest
            {
                Query = "query searchAccount { account { search(pagination: {}, filter: {}, ordering: {}) { items { id, email, type, name } } } }"
            };
        }

        public static GraphQLRequest CreateScheduleMutation(string reportId, DateTime startDate, DateTime finishDate)
        {
            return new GraphQLRequest
            {
                Query =
                    "mutation addSchedule($schedule: ScheduleCreateViewModel!) { schedule { addSchedule(schedule:$schedule){ id, reportId, startDate, finishDate } } }",
                Variables = new {schedule = new {reportId, startDate, finishDate}}
            };
        }

        public static GraphQLRequest CreateContributorMutation(string userId, string reportId)
        {
            return new GraphQLRequest
            {
                Query =
                    "mutation addContributor($contributor: ContributorCreateViewModel!) { contributor { addContributor(contributor:$contributor){ id,userId,reportId } } }",
                Variables = new {schedule = new {userId, reportId}}
            };
        }

        public static GraphQLRequest CreateLoginMutation(string email, string password)
        {
            return new GraphQLRequest
            {
                Query = "mutation ($request:LoginRequestCreateViewModel!) { login { login(request: $request){ success, error} } }",
                Variables = new {request = new {email, password}}
            };
        }
        

    }
}