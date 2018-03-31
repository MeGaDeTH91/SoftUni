using System;
using System.Collections.Generic;
using System.Linq;

public class Judge : IJudge
{
    public HashSet<int> Users { get; set; }
    public HashSet<int> Contests { get; set; }
    public Dictionary<int, Submission> Submissions { get; set; }

    public Judge()
    {
        this.Users = new HashSet<int>();
        this.Contests = new HashSet<int>();
        this.Submissions = new Dictionary<int, Submission>();
    }

    public void AddContest(int contestId)
    {
        this.Contests.Add(contestId);
    }

    public void AddSubmission(Submission submission)
    {
        var userExists = this.Users.Contains(submission.UserId);
        var contestExists = this.Contests.Contains(submission.ContestId);
        if (!userExists || !contestExists)
        {
            throw new InvalidOperationException();
        }
        if(!this.Submissions.ContainsKey(submission.Id))
        {
            this.Submissions.Add(submission.Id, submission);
        }
    }

    public void AddUser(int userId)
    {
        this.Users.Add(userId);
    }

    public void DeleteSubmission(int submissionId)
    {
        if (!this.Submissions.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }
        this.Submissions.Remove(submissionId);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return this.Submissions.Values.OrderBy(x => x.Id);
    }

    public IEnumerable<int> GetUsers()
    {
        return this.Users.OrderBy(x => x);
    }

    public IEnumerable<int> GetContests()
    {
        return this.Contests.OrderBy(x => x);
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        var neededSubmissions = this.Submissions.Where(x => x.Value.Points >= minPoints && x.Value.Points <= maxPoints && x.Value.Type == submissionType).Select(x => x.Value);

        return neededSubmissions;
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        if (!this.Users.Contains(userId))
        {
            throw new InvalidOperationException();
        }
        var neededContests = this.Submissions.Where(x => x.Value.UserId == userId).OrderByDescending(x => x.Value.Points).ThenBy(x => x.Value.Id).Select(x => x.Value.ContestId).Distinct();

        return neededContests;
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        bool contestExists = this.Contests.Contains(contestId);
        bool userExists = this.Users.Contains(userId);

        if(!contestExists || !userExists)
        {
            throw new InvalidOperationException();
        }

        var neededSubmissions = this.Submissions.Where(x => x.Value.ContestId == contestId && x.Value.UserId == userId && x.Value.Points == points).Select(x => x.Value).ToList();
        if(neededSubmissions.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return neededSubmissions;
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        HashSet<int> contests = new HashSet<int>(this.Submissions.Where(x => x.Value.Type == submissionType).Select(x => x.Value.ContestId));
        return contests;
    }
}
