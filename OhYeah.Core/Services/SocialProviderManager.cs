using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using OhYeah.Core.Social.Facebook;
using OhYeah.Core.Social.Instagram;

namespace OhYeah.Core.Services
{
    public class SocialProviderManager : ISocialProviderManager
    {
        public SocialProviderManager(IApplicationSettingsService applicationSettingsService)
        {
            Facebook = new FacebookProvider(applicationSettingsService);
            Instagram = new InstagramProvider(applicationSettingsService);
        }

        public ISocialProvider Facebook { get; }
        public ISocialProvider Instagram { get; }

        public async Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = new CancellationToken())
        {
            var taskList = new List<Task<List<DateGroup<OhYeahPost>>>> {Facebook.GetPosts(cancellationToken), Instagram.GetPosts(cancellationToken)};

            var results = await Task.WhenAll(taskList);

            var list = new List<DateGroup<OhYeahPost>>();
            foreach (var result in results)
            {
                foreach (var date in result)
                {
                    if (date.Date == DateTime.MinValue)
                    {
                        continue;
                    }

                    var existingDate = list.FirstOrDefault(x => x.Date == date.Date);
                    if (existingDate != null)
                    {
                        existingDate.AddRange(date);
                    }
                    else
                    {
                        list.Add(date);
                    }
                }
            }

            return list;
        }
    }
}
