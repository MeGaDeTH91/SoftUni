using System.Collections.Generic;

public class Group : IAttackGroup
{
    List<IAttacker> attackers;

    public Group()
    {
        this.attackers = new List<IAttacker>();
    }

    public void AddMember(IAttacker attacker)
    {
        this.attackers.Add(attacker);
    }

    public void GroupAttack()
    {
        foreach (var attacker in this.attackers)
        {
            attacker.Attack();
        }
    }

    public void GroupTarget(ITarget target)
    {
        this.attackers.ForEach(x => x.SetTarget(target));
    }

    public void GroupTargetAndAttack(ITarget target)
    {
        this.GroupTarget(target);
        this.GroupAttack();
    }
}
