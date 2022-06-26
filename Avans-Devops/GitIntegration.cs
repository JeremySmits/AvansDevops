using Avans_Devops.Pipelines;
using Avans_Devops.Releases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class GitIntegration
    {
        public IRelease Release {get;set;}
        public Sprint Sprint { get; set; }
        public static void Pull() { Console.WriteLine("Pulled latest version from git."); }
        public static void Push() { Console.WriteLine("Pushed changes to git."); }
        public static void Commit(string BranchName) { Console.WriteLine("Commited changes to " + BranchName); }
        public static void NewBranch(string BranchName) { Console.WriteLine("New branch" + BranchName + " has been added."); }
        public static void SwitchBranch(string BranchName) { Console.WriteLine("You have switched to branch :" + BranchName ); }
        public static void Stash() { Console.WriteLine("Stashed the changes."); }
        public static void Pop() { Console.WriteLine("Popped the changes."); }
        public void CommitAndPushToMaster()
        {
            Release = new SuccesRelease(Sprint);
            Release.Proceed();
            Console.WriteLine("Commited changes to Master"); 
        }
        public void CommitAndPushToMasterFail()
        {
            Release = new FailRelease(Sprint);
            Release.Proceed();
            Console.WriteLine("Commited changes to Master"); 
        }
    }
}
