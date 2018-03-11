using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Judge : IJudge
{
    SortedSet<int> users;
    SortedSet<int> contests;
    Dictionary<int, Submission> submissions;
    Dictionary<SubmissionType, HashSet<int>> contestsBySubmissionType;

    public Judge()
    {
        this.users = new SortedSet<int>();
        this.contests = new SortedSet<int>();
        this.submissions = new Dictionary<int, Submission>();
        this.contestsBySubmissionType = new Dictionary<SubmissionType, HashSet<int>>();
    }

    public void AddContest(int contestId)
    {
        this.contests.Add(contestId);
    }

    public void AddSubmission(Submission submission)
    {
        if (!this.submissions.ContainsKey(submission.Id))
        {
            if(!this.users.Contains(submission.UserId) || !this.contests.Contains(submission.ContestId))
            {
                throw new InvalidOperationException();
            }
            this.submissions.Add(submission.Id, submission);
            if (!this.contestsBySubmissionType.ContainsKey(submission.Type))
            {
                this.contestsBySubmissionType[submission.Type] = new HashSet<int>();
            }
            this.contestsBySubmissionType[submission.Type].Add(submission.ContestId);
        }
    }

    public void AddUser(int userId)
    {
        this.users.Add(userId);
    }

    public void DeleteSubmission(int submissionId)
    {
        if (!this.submissions.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }
        var sub = this.submissions[submissionId];
        this.submissions.Remove(submissionId);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return this.submissions.Values.OrderBy(x => x.Id);
    }

    public IEnumerable<int> GetUsers()
    {
        return this.users;
    }

    public IEnumerable<int> GetContests()
    {
        return this.contests;
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        return this.submissions.Values.Where(x => x.Type == submissionType && x.Points >= minPoints && x.Points <= maxPoints);
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        if (!this.users.Contains(userId))
        {
            throw new InvalidOperationException();
        }
        HashSet<int> temp = new HashSet<int>(this.submissions.Where(x => x.Value.UserId == userId).OrderByDescending(x => x.Value.Points).ThenBy(x => x.Value.Id).Select(x => x.Value.ContestId));

        return temp;
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        if(!this.contests.Contains(contestId) || !this.users.Contains(userId) || points < 0)
        {
            throw new InvalidOperationException();
        }
        var temp = this.submissions.Values.Where(x => x.ContestId == contestId && x.UserId == userId && x.Points == points).ToList();
        if(temp.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return temp;
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        HashSet<int> temp = new HashSet<int>();
        if (this.contestsBySubmissionType.ContainsKey(submissionType))
        {
            temp = this.contestsBySubmissionType[submissionType];
        }
        return temp;
    }
}
