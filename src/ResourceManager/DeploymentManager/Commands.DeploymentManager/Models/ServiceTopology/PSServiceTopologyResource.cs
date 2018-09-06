﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public class PSServiceTopologyResource : PSResource
    {
        public PSServiceTopologyResource() : base()
        {
        }

        public PSServiceTopologyResource(
            string resourceGroup,
            ServiceTopologyResource topologyResource) : base(topologyResource)
        {
            this.ResourceGroupName = resourceGroup;
            this.ArtifactSourceId = topologyResource.ArtifactSourceId;
        }

        /// <summary>
        /// Gets or sets the resource group to which the service unit belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

		/// <summary>
		/// Gets or sets the artifact store that contains the artifacts that
		/// make up the topology components.
		/// </summary>
		public string ArtifactSourceId { get; set; }

        internal ServiceTopologyResource ToSdkType()
        {
            return new ServiceTopologyResource(
                this.Location,
                this.ArtifactSourceId,
                this.Name,
                this.Type,
                this.Id,
                TagsConversionHelper.CreateTagDictionary(this.Tags, validate: true));
        }
    }
}
