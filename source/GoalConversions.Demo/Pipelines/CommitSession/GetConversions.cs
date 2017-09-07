using System.Linq;

using Sitecore.Analytics.Pipelines.CommitSession;
using Sitecore.Analytics.Tracking;
using Sitecore.Diagnostics;

namespace GoalConversions.Demo.Pipelines.CommitSession
{
	public class GetConversions : CommitSessionProcessor
	{
		public override void Process(CommitSessionPipelineArgs args)
		{
			Assert.ArgumentNotNull(args, "args");
			Assert.IsNotNull(args.Session, "args.Session is not set");

			GetSessionConversions(args.Session);
		}

		private void GetSessionConversions(Session session)
		{
			if (session.Interaction == null)
			{
				return;
			}

			var conversions = session.Interaction.Pages.SelectMany(x => x.PageEvents).Where(g => g.IsGoal);

			if (!conversions.Any())
			{
				return;
			}

			var goalNames = string.Join("|", conversions.Select(x => x.Name));
			Log.Info($"[Contact Conversion Demo] Contact id {session.Contact.ContactId} triggered the following goals: {goalNames}", this);
		}
	}
}